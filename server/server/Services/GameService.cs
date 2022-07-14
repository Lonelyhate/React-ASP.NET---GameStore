using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models.Enums;
using server.Models.Games;
using server.Models.Responses;
using server.Services.Interfaces;

namespace server.Services;

public class GameService : IGameService
{
    private readonly ApplicationDbContext _dbContext;

    public GameService(ApplicationDbContext db)
    {
        _dbContext = db;
    }

    public async Task<BaseResponse<Game>> Create(Game game)
    {
        var baseResponse = new BaseResponse<Game>();

        try
        {
            var _game = await _dbContext.Games.FirstOrDefaultAsync(g => g.Title == game.Title);
            if (_game is not null)
            {
                baseResponse.Description = "Игра с таким названием уже есть";
                baseResponse.StatusCodes = StatusCode.Error;
                return baseResponse;
            }
            await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();
            baseResponse.Data = game;
            baseResponse.StatusCodes = StatusCode.OkCreated;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Game>()
            {
                Description = $"Game create - {e.Message}",
                StatusCodes = StatusCode.InternalServer
            };
        }
    }

    public async Task<BaseResponse<Game>> GetById(int id)
    {
        var baseResponse = new BaseResponse<Game>();

        try
        {
            var game = await _dbContext.Games.FirstOrDefaultAsync(g => g.Id == id);
            if (game is null)
            {
                baseResponse.Description = "Game not found";
                baseResponse.StatusCodes = StatusCode.NotFound;
                return baseResponse;
            }

            baseResponse.Data = game;
            baseResponse.StatusCodes = StatusCode.Ok;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Game>()
            {
                Description = $"GetById - {e.Message}",
                StatusCodes = StatusCode.InternalServer
            };
        }
    }

    public async Task<BaseResponse<IEnumerable<Game>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<Game>>();

        try
        {
            var games = await _dbContext.Games.ToListAsync();
            if (games.Count == 0)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCodes = StatusCode.Ok;
                return baseResponse;
            }

            baseResponse.Data = games;
            baseResponse.StatusCodes = StatusCode.Ok;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Game>>()
            {
                Description = $"GetAll - {e.Message}",
                StatusCodes = StatusCode.InternalServer
            };
        }
    }
    
    public async Task<BaseResponse<bool>> Delete (int id)
    {
        var baseResponse = new BaseResponse<bool>();

        try
        {
            var game = await _dbContext.Games.FirstOrDefaultAsync(g => g.Id == id);

            if (game is null)
            {
                baseResponse.Description = "Нет такой игры";
                baseResponse.StatusCodes = StatusCode.NotFound;
                return baseResponse;
            }

            _dbContext.Remove(game);
            await _dbContext.SaveChangesAsync();
            
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCodes = StatusCode.Ok;
            baseResponse.Data = true;
            return baseResponse;

        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Description = $"Delete - {e.Message}",
                StatusCodes = StatusCode.InternalServer
            };
        }
    }

    public async Task<BaseResponse<IEnumerable<Game>>> SearchGame(string str)
    {
        var baseResponse = new BaseResponse<IEnumerable<Game>>();

        try
        {
            var games = (from g in _dbContext.Games
                where EF.Functions.Like(g.Title, "%"+ str + "%") 
                select g).ToList();

            if (games.Count == 0)
            {
                baseResponse.Description = "Ничего не найдено";
                baseResponse.StatusCodes = StatusCode.Ok;
                return baseResponse;
            }

            baseResponse.Data = games;
            baseResponse.StatusCodes = StatusCode.Ok;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Game>>()
            {
                Description = $"Delete - {e.Message}",
                StatusCodes = StatusCode.InternalServer
            };
        }
    }
}