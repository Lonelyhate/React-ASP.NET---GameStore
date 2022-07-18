using server.Models.Responses;

namespace server.Models.Requests;

public class LoginRequestModel
{
    public string Login { get; set; }
    
    public string Password { get; set; }
}
