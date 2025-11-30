using AuthService.Services.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers;

[Route("api/auth/")]
[ApiController]
public class AdminController
{
    private readonly IUserService _userService;

    public AdminController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("users")]
    public async Task<IResult> GetUsers()
    {
        try
        {
            return Results.Ok(await _userService.GetUsers());
        } catch (Exception ex)
        {
            return Results.BadRequest($"Error while retrieving users: {ex.Message}");
        }
    }
    
}