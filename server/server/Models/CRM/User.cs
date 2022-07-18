using server.Models.Enums;

namespace server.Models;

public class User : BaseModel
{
    public string Login { get; set; }
    
    public byte[] PasswordHash { get; set; }
    
    public byte[] PasswordSalt { get; set; }
    
    public Role Role { get; set; }
}