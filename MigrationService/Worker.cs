using API.Data;
using DomainModels;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using OpenTelemetry.Trace;
using System.Threading;
using Microsoft.IdentityModel.Tokens;

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
    private async Task SeedDataAsync(HotelContext dbContext, CancellationToken cancellationToken)
    {
        // Create a new room object with sample data.
        Room testRoom = new()
        {
            RoomType = new RoomType()
            {
                RoomTypeName = "Single Room",
                Tags = new List<string> { "Single" },
            },
            Rooms = 1,
            RoomNumber = 101,
            Beds = "Single",
            Price = 100,
            Status = "Available",
            Condition = "Good"
        };

        // Try to seed the database with the sample room data.
        var success = TrySeedEntity<Room>(dbContext, testRoom);

        // Log the result of the seeding operation.
        _logger.LogDebug(success ? "Sample room was created" : "Room table already contains data. Room was skipped.");
    }

    /// <summary>
    /// Using provided entity, try to seed the database with sample data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dbContext"></param>
    /// <param name="entity"></param>
    /// <returns>True if successful, false if database table of entity already contains data</returns>
    private bool TrySeedEntity<T>(HotelContext dbContext, T entity) where T : class
    {
        var existingEntity = !dbContext.Set<T>().IsNullOrEmpty();
        if (existingEntity)
        {
            return false;
        }

        dbContext.Set<T>().Add(entity);
        dbContext.SaveChanges();
        return true;
    }
}
