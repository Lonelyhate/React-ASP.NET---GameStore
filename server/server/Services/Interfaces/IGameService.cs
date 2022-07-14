using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models.Games;
using server.Models.Responses;

namespace server.Services.Interfaces;

public interface IGameService : IBaseService<Game>
{
    Task<BaseResponse<IEnumerable<Game>>> SearchGame(string str);
}