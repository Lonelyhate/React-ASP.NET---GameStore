using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models.Enums;
using server.Models.Games;
using server.Models.Requests.Game;
using server.Models.Responses;
using server.Models.Responses.Game;
using server.Services.Interfaces;

namespace server.Services;

public class GameService : IGameService
{
    private readonly ApplicationDbContext _dbContext;

    public GameService(ApplicationDbContext db)
    {
        _dbContext = db;
    }

    public async Task<CreateGameResponseModel> CreateGame(CreateGameRequestModel model)
    {
        var baseResponse = new CreateGameResponseModel();

        try
        {
            var _game = await _dbContext.Games.FirstOrDefaultAsync(g => g.Title == model.Title);
            if (_game is not null)
            {
                baseResponse.Description = "Игра с таким названием уже есть";
                baseResponse.StatusCodes = StatusCode.Error;
                return baseResponse;
            }

            Game game = new Game()
            {
                Title = model.Title,
                Description = model.Descrption,
                GameCategory = model.GameCategory
            };

            CreateGameModel _model = new CreateGameModel()
            {
                Title = game.Title,
                Description = game.Description,
                GameCategory = game.GameCategory
            };

            await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();
            baseResponse.Data = _model;
            baseResponse.StatusCodes = StatusCode.OkCreated;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new CreateGameResponseModel()
            {
                Description = $"Game create - {e.Message}",
                StatusCodes = StatusCode.InternalServer
            };
        }
    }

    public async Task<GetGameByIdResponseModel> GetGame(int id)
    {
        var baseResponse = new GetGameByIdResponseModel();

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
            return new GetGameByIdResponseModel()
            {
                Description = $"GetById - {e.Message}",
                StatusCodes = StatusCode.InternalServer
            };
        }
    }

    public async Task<GetGamesResponseModel> GetAll()
    {
        var baseResponse = new GetGamesResponseModel();

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
            return new GetGamesResponseModel()
            {
                Description = $"GetAll - {e.Message}",
                StatusCodes = StatusCode.InternalServer
            };
        }
    }
    
    public async Task<GameDeleteResponseModel> DeleteGame(int id)
    {
        var baseResponse = new GameDeleteResponseModel();

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

            GameDeleteModel deleteResponse = new GameDeleteModel()
            {
                Success = true
            };

            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCodes = StatusCode.Ok;
            baseResponse.Data = deleteResponse;
            return baseResponse;

        }
        catch (Exception e)
        {
            return new GameDeleteResponseModel()
            {
                Description = $"Delete - {e.Message}",
                StatusCodes = StatusCode.InternalServer
            };
        }
    }

    public async Task<GameSearchResponseModel> SearchGame(string str)
    {
        var baseResponse = new GameSearchResponseModel();

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
            return new GameSearchResponseModel()
            {
                Description = $"Delete - {e.Message}",
                StatusCodes = StatusCode.InternalServer
            };
        }
    }
}