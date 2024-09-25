using API.Data;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using DomainModels.DB;

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
        // Create a new room type object with sample data.
        List<RoomType> roomTypes = new()
        {
            new PentHouse(),
            new PremiumHouse(),
            new StandardHouse()
        };

        TrySeedEntities<RoomType>(dbContext, roomTypes);

        // Create a new room object with sample data.
        List<Room> rooms = new()
        {

            new()
            {
                RoomType = roomTypes[0],
                Rooms = 1,
                RoomNumber = 101,
                Beds = "Single",
                Price = 100,
                Status = "Available",
                Condition = "Good",
                Description = "This is a single room with a single bed."
            },

            new()
            {
                RoomType = roomTypes[1],
                Rooms = 1,
                RoomNumber = 102,
                Beds = "Double",
                Price = 200,
                Status = "Available",
                Condition = "Good",
                Description = "This is a double room with a double bed."
            }
        };
     
        // Try to seed the database with the sample room data.
        var success = TrySeedEntities<Room>(dbContext, rooms);

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
    private bool TrySeedEntities<T>(HotelContext dbContext, IEnumerable<T> entities) where T : class
    {

        var existingEntityCount = dbContext.Set<T>().Count();
        if (existingEntityCount == entities.Count())
        {
            return false;
        }

        entities.ToList().ForEach(e =>
        {
            dbContext.Set<T>().Add(e);
        });
        dbContext.SaveChanges();
        return true;
    }
}
