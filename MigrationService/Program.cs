using API.Data;
using MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry().WithTracing(tracing => tracing.AddSource(Worker.ActivityName));

builder.AddNpgsqlDbContext<HotelContext>("hoteldb");

var host = builder.Build();
host.Run();
