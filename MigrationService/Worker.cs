using API.Data;
using DomainModels;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using OpenTelemetry.Trace;
using System.Threading;

namespace MigrationService;

// Worker class is a background service that runs when the application starts.
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

    /// <summary>
    /// ExecuteAsync is the main method that runs when the worker service starts.
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Start a new OpenTelemetry activity for the migration process.
        using var activity = _activitySource.StartActivity("Migrating database", ActivityKind.Client);

        // Create a new scope for the service provider and get the database context.
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HotelContext>();
        
        // Ensure the database is created and migrated.
        try
        {
            await dbContext.Database.EnsureCreatedAsync(stoppingToken);
        }
        catch (Exception ex)
        {
            // Log the exception if the database creation fails.
            activity?.AddEvent(new ActivityEvent($"EnsureCreated failed with following exception: {ex.Message} - {ex.StackTrace}"));
        }

        // Migrate the database.
        try
        {
            await dbContext.Database.MigrateAsync(stoppingToken);
        }
        catch (Exception ex)
        {
            // Log the exception if the database migration fails.
            activity?.AddEvent(new ActivityEvent($"Migration failed with following exception: {ex.Message} - {ex.StackTrace}"));
        }

#if DEBUG
        // Seed the database with sample data if we're running the debug configuration.
        await SeedDataAsync(dbContext, stoppingToken);
        activity?.AddEvent(new ActivityEvent("Seeding sample data"));
#endif

        // Stop the application when the worker service is done.
        hostApplicationLifetime.StopApplication();
    }

    /// <summary>
    /// SeedDataAsync is a method that seeds the database with sample data.
    /// </summary>
    /// <param name="dbContext"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private static async Task SeedDataAsync(HotelContext dbContext, CancellationToken cancellationToken)
    {
        // Create a new room object with sample data.
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

        // Use the database execution strategy to seed the database.
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
