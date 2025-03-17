using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.DTOs.Users;

namespace API.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationservice;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationservice = authenticationService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO user)
    {
        var token = await _authenticationservice.LoginAsync(user);
        return token is null ? Unauthorized() : Ok(new { Token = token });
    }
}