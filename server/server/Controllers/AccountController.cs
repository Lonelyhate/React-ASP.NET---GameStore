using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Models.Requests;
using server.Models.Responses;
using server.Models.Responses.Auth;
using server.Services.Interfaces;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponseModel>> Register(RegisterRequestModel model)
    {
        var response = await _accountService.Register(model);

        if (response.StatusCodes == Models.Enums.StatusCode.Error)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
    {
        var response = await _accountService.Login(model);

        if (response.StatusCodes == Models.Enums.StatusCode.NotFound)
        {
            return NotFound(response);
        }

        if (response.StatusCodes == Models.Enums.StatusCode.Error)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}