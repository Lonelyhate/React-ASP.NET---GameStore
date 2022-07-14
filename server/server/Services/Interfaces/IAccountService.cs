using System.Security.Claims;
using server.Models;
using server.Models.Responses;
using server.Models.ViewModels;

namespace server.Services.Interfaces;

public interface IAccountService
{
    Task<BaseResponse<User>> Register(RegisterViewModel model);

    Task<BaseResponse<string>> Login(LoginViewModel model);
}