using BT.Common.Api.Helpers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokeGame.Core.Domain.Services.User.Abstract;
using PokeGame.Core.Schemas;
using PokeGame.Core.Schemas.Input;

namespace PokeGame.Core.Api.Controllers;

[ApiController]
[Route("Api/[controller]")]
[AllowAnonymous]
public sealed class UserController: ControllerBase
{
    private readonly IUserProcessingManager _userProcessingManager;

    public UserController(IUserProcessingManager userProcessingManager)
    {
        _userProcessingManager = userProcessingManager;
    }

    [HttpGet]
    public Task<ActionResult<WebOutcome<User>>> GetUser(Guid userId)
    {
        throw new NotImplementedException();
    }
    [HttpPost]
    public async Task<ActionResult<WebOutcome<User>>> SaveUser(SaveUserInput input)
    {
        var result =  await _userProcessingManager.SaveUserAsync(input);

        return Ok(new WebOutcome<User>
        {
            Data = result,
            ExtraData = new Dictionary<string, object>
            {
                {"SaveType", input.Id is null ? "Create": "Update"}
            }
        });
    } 
}