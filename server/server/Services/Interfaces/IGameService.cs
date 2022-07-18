using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models.Games;
using server.Models.Requests.Game;
using server.Models.Responses;
using server.Models.Responses.Game;

namespace server.Services.Interfaces;

public interface IGameService
{
    Task<GetGamesResponseModel> GetAll();

    Task<CreateGameResponseModel> CreateGame(CreateGameRequestModel model);

    Task<GetGameByIdResponseModel> GetGame(int id);

    Task<GameDeleteResponseModel> DeleteGame(int id);
    
    Task <GameSearchResponseModel> SearchGame(string str);
}