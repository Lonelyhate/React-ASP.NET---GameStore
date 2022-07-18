using System.Security.Claims;
using server.Models;
using server.Models.Requests;
using server.Models.Responses;
using server.Models.Responses.Auth;

namespace server.Services.Interfaces;

public interface IAccountService
{
    Task<RegisterResponseModel> Register(RegisterRequestModel model);

    Task<LoginResponseModel> Login(LoginRequestModel model);
}