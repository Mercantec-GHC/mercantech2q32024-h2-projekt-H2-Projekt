using API.Data;
using MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

// Add OpenTelemetry to the service. This is basically a sort of event logging.
builder.Services.AddOpenTelemetry().WithTracing(tracing => tracing.AddSource(Worker.ActivityName));

// Add the database context to the service.
builder.AddNpgsqlDbContext<HotelContext>("hoteldb");
var host = builder.Build();
host.Run();
