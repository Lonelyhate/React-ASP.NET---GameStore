using Newtonsoft.Json;

namespace server.Models.Responses.Game;

public class GameDeleteModel
{
    [JsonProperty("success")]
    public bool Success { get; set; }
}

public class GameDeleteResponseModel : BaseResponse<GameDeleteModel>
{
    
}