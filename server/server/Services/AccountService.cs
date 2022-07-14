using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using server.Data;
using server.Helpers;
using server.Helpers.Interfaces;
using server.Models;
using server.Models.Enums;
using server.Models.Responses;
using server.Models.ViewModels;
using server.Services.Interfaces;

namespace server.Services;

public class AccountService : IAccountService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IAccountHelper _accountHelper;

    public AccountService(ApplicationDbContext dbContext, IAccountHelper accountHelper)
    {
        _dbContext = dbContext;
        _accountHelper = accountHelper;
    }

    public async Task<BaseResponse<User>> Register(RegisterViewModel model)
    {
        try
        {
            var baseResponse = new BaseResponse<User>();
            Console.WriteLine("111");
            var userCheck = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == model.Login);
            Console.WriteLine("222");
            if (userCheck is not null)
            {
                
                baseResponse.Description = "Пользователь с таким логином уже есть";
                baseResponse.StatusCodes = StatusCode.Error;
                return baseResponse;
            }

            _accountHelper.CreatedPasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User()
            {
                Login = model.Login,
                Role = Role.User,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            baseResponse.Data = user;
            baseResponse.StatusCodes = StatusCode.OkCreated;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<User>()
            {
                StatusCodes = StatusCode.InternalServer,
                Description = e.Message
            };
        }
    }

    public async Task<BaseResponse<string>> Login(LoginViewModel model)
    {
        try
        {
            var baseResponse = new BaseResponse<string>();

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == model.Login);
            if (user is null)
            {
                baseResponse.Data = "Пользователя с таким логином нет";
                baseResponse.StatusCodes = StatusCode.NotFound;
                return baseResponse;
            }
            
            if (!_accountHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                baseResponse.Data = "Пароль неправильный";
                baseResponse.StatusCodes = StatusCode.Error;
                return baseResponse;
            }

            string token = _accountHelper.CreateToken(user);

            baseResponse.Data = token;
            baseResponse.StatusCodes = StatusCode.Ok;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<string>()
            {
                Description = e.Message,
                StatusCodes = StatusCode.InternalServer
            };
        }
    }
}