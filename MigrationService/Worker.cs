using API.Data;
using DomainModels;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using OpenTelemetry.Trace;
using System.Threading;

namespace MigrationService;

public class Worker : BackgroundService
{
    private readonly IServiceProvider serviceProvider;
    private readonly IHostApplicationLifetime hostApplicationLifetime;
    private readonly ILogger<Worker> _logger;

    internal const string ActivityName = "MigrationService";
    private static readonly ActivitySource _activitySource = new(ActivityName);

    public Worker(IServiceProvider serviceProvider,
        IHostApplicationLifetime hostApplicationLifetime,
        ILogger<Worker> logger)
    {
        this.serviceProvider = serviceProvider;
        this.hostApplicationLifetime = hostApplicationLifetime;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var activity = _activitySource.StartActivity("Migrating database", ActivityKind.Client);

        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HotelContext>();
        
        try
        {
            await dbContext.Database.EnsureCreatedAsync(stoppingToken);
        }
        catch (Exception ex)
        {
            activity?.AddEvent(new ActivityEvent($"EnsureCreated failed with following exception: {ex.Message} - {ex.StackTrace}"));
        }

        try
        {
            await dbContext.Database.MigrateAsync(stoppingToken);
        }
        catch (Exception ex)
        {
            activity?.AddEvent(new ActivityEvent($"Migration failed with following exception: {ex.Message} - {ex.StackTrace}"));
        }

#if DEBUG
        await SeedDataAsync(dbContext, stoppingToken);
        activity?.AddEvent(new ActivityEvent("Seeding sample data"));
#endif

        hostApplicationLifetime.StopApplication();
    }

    private static async Task SeedDataAsync(HotelContext dbContext, CancellationToken cancellationToken)
    {
        Room testRoom = new()
        {
            RoomType = new List<string> { "Single" },
            Rooms = 1,
            RoomNumber = 101,
            Beds = "Single",
            Price = 100,
            Status = "Available",
            Condition = "Good"
        };

        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            // Seed the database
            await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
            await dbContext.Rooms.AddAsync(testRoom, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        });
    }
}
