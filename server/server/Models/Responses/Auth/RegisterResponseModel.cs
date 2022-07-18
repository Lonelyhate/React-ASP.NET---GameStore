using Newtonsoft.Json;
using server.Models.Enums;

namespace server.Models.Responses.Auth;

public class RegisterModel
{
    [JsonProperty("login")]
    public string Login { get; set; }
    
    [JsonProperty("role")]
    public Role Role { get; set; }
    
    [JsonProperty("token")]
    public string Token { get; set; }
}

public class RegisterResponseModel : BaseResponse<RegisterModel>
{
    
}