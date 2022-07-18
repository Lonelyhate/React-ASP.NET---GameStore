using System.ComponentModel.DataAnnotations;
using server.Models.Enums;

namespace server.Models.Games;

public class Game : BaseModel
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public GameCategory GameCategory { get; set; }
}