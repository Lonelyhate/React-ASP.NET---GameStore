using Newtonsoft.Json;
using server.Models.Enums;

namespace server.Models.Requests.Game;

public class CreateGameRequestModel
{
    [JsonProperty("title")]
    public string Title { get; set; }
    
    [JsonProperty("description")]
    public string Descrption { get; set; }
    
    [JsonProperty("game_category")]
    public GameCategory GameCategory { get; set; }
}