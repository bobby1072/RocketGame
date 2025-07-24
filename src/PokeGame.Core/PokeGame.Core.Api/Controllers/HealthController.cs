using BT.Common.Api.Helpers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokeGame.Core.Common.Configurations;

namespace PokeGame.Core.Api.Controllers;

[ApiController]
[Route("Api/[controller]")]
[AllowAnonymous]
public sealed class HealthController: ControllerBase
{
    private readonly ILogger<HealthController> _logger;
    private readonly ServiceInfo _serviceInfo;
    
    public HealthController(ILogger<HealthController> logger, ServiceInfo serviceInfo)
    {
        _logger = logger;
        _serviceInfo = serviceInfo;
    }


    [HttpGet]
    public Task<ActionResult<WebOutcome<ServiceInfo>>> Health()
    {
        _logger.LogInformation("Service appears healthy...");
        
        return Task.FromResult((ActionResult<WebOutcome<ServiceInfo>>)new WebOutcome<ServiceInfo>
            { Data = _serviceInfo });
    }
}