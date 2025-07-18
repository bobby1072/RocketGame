using PokeGame.Core.Common;

namespace PokeGame.Core.Api.Middlewares;

internal sealed class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;

    public CorrelationIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ILogger<CorrelationIdMiddleware> logger)
    {
        var newCorrelationId = Guid.NewGuid().ToString();

        if (!context.Response.Headers.TryAdd(MiscConstants.CorrelationIdHeader, newCorrelationId))
        {
            logger.LogWarning("Failed to add correlationId: {CorrelationId} to http response headers", newCorrelationId);
        }
        else
        {
            logger.LogInformation("CorrelationId: {CorrelationId} added to request headers successfully", newCorrelationId);
        }
        
        // Optional: store in context.Items for later retrieval in the pipeline
        context.Items[MiscConstants.CorrelationIdHeader] = newCorrelationId;

        // Use a logging scope to propagate the CorrelationId
        using (logger.BeginScope(new Dictionary<string, object>
               {
                   [MiscConstants.CorrelationIdHeader] = newCorrelationId
               }))
        {
            await _next.Invoke(context);
        }
    }
}