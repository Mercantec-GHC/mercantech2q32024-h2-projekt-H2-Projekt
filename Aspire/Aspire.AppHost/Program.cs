var builder = DistributedApplication.CreateBuilder(args);

#region DBSetup
// Add Postgres server
var dbServer = builder.AddPostgres("dbserver");
// Add database "hoteldb"
var db = dbServer.AddDatabase("hoteldb");
// Add a data volume (Let aspire know to keep data between startups) and add pgAdmin
dbServer.WithDataVolume().WithPgAdmin();
#endregion

#region API
// Add API project with reference to DB project
var api = builder.AddProject<Projects.API>("api").WithReference(db);
#endregion

#region Frontend
// Add Blazor project with reference to API project
builder.AddProject<Projects.Blazor>("blazor").WithReference(api);
#endregion

#region Migrations Worker
// Truly you do not need to worry about this as it just runs migrations and seeds the database if the run configuration is set to "Debug"
builder.AddProject<Projects.MigrationService>("migrations").WithReference(db);
#endregion

builder.Build().Run();
