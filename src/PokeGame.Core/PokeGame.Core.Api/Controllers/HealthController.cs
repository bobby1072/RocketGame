using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokeGame.Core.Api.Models;
using PokeGame.Core.Common;
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
        try
        {
            _logger.LogInformation("Service appears healthy...");
            
            return Task.FromResult((ActionResult<WebOutcome<ServiceInfo>>)new WebOutcome<ServiceInfo>
                { Data = _serviceInfo });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An exception occurred during the health route with message: {Message}", ex.Message);
            
            return Task.FromResult(
                (ActionResult<WebOutcome<ServiceInfo>>)
                    new WebOutcome<ServiceInfo>
                    {
                        ExceptionMessage = ExceptionConstants.InternalError
                    });    
        }
    }
}