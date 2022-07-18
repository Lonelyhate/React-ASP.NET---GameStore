using Newtonsoft.Json;
using server.Models.Enums;

namespace server.Models.Responses.Game;

public class GetGamesResponseModel : BaseResponse<IEnumerable<Games.Game>>
{
    
}