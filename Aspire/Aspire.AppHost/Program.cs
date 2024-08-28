var builder = DistributedApplication.CreateBuilder(args);

#region DBSetup
var dbServer = builder.AddPostgres("dbserver");
var db = dbServer.AddDatabase("hoteldb");
dbServer.WithDataVolume().WithPgAdmin();
#endregion

#region API
var api = builder.AddProject<Projects.API>("api").WithReference(db);
#endregion

#region Frontend
builder.AddProject<Projects.Blazor>("blazor").WithReference(api);
#endregion

builder.Build().Run();
