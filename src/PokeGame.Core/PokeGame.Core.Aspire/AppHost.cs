var builder = DistributedApplication.CreateBuilder(args);

builder
    .AddProject<Projects.PokeGame_Core_Api>("PokeGame-Core-Api")
    .WithExternalHttpEndpoints();


await builder.Build().RunAsync();