using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers;

[Route("api/auth/")]
[ApiController]
public class AdminController
{
    [HttpGet("users")]
    public IResult GetUsers()
    {
        return Results.Ok();
    }
    
}