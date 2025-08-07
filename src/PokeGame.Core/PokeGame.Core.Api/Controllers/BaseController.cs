using Microsoft.AspNetCore.Mvc;

namespace PokeGame.Core.Api.Controllers;

[ApiController]
[Route("Api/[controller]")]
public abstract class BaseController: ControllerBase
{ }