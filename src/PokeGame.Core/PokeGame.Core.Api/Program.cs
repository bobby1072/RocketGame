using BT.Common.Helpers;
using PokeGame.Core.Api.Middlewares;
using PokeGame.Core.Domain.Services.Extensions;

var localLogger = LoggingHelper.CreateLogger();

try
{
    localLogger.LogInformation("Application starting...");
    
    var builder = WebApplication.CreateBuilder(args);
    
    builder.Services
        .AddPokeGameApplicationServices(builder.Configuration, builder.Environment);

    builder.Services.AddLogging(opts =>
    {
        opts.AddJsonConsole(ctx =>
        {
            ctx.IncludeScopes = true;
        });
    });
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddResponseCompression();
    
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseRouting();

    app.UseResponseCompression();
    
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app
        .UseMiddleware<ExceptionHandlingMiddleware>()
        .UseMiddleware<CorrelationIdMiddleware>();
    
    app.MapControllers();

    await app.RunAsync();
}
catch (Exception ex)
{
    localLogger.LogCritical(ex, "Unhandled exception in application with message: {ExMessage}", ex.Message);
}
finally
{
    localLogger.LogInformation("Application is exiting...");
}
