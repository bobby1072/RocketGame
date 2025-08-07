using BT.Common.Api.Helpers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokeGame.Core.Common.Configurations;
using PokeGame.Core.Schemas.Output;

namespace PokeGame.Core.Api.Controllers;

[AllowAnonymous]
public sealed class HealthController: BaseController
{
    private readonly ILogger<HealthController> _logger;
    private readonly ServiceInfo _serviceInfo;
    
    public HealthController(ILogger<HealthController> logger, ServiceInfo serviceInfo)
    {
        _logger = logger;
        _serviceInfo = serviceInfo;
    }


    [HttpGet]
    public Task<ActionResult<WebOutcome<HealthResponse>>> Health()
    {
        _logger.LogInformation("Service appears healthy...");
        
        return Task.FromResult((ActionResult<WebOutcome<HealthResponse>>)new WebOutcome<HealthResponse>
        {
            Data = new HealthResponse
            {
                ServiceInfo = _serviceInfo,
            },
            
        });
    }
}