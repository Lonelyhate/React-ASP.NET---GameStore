using System.ComponentModel.DataAnnotations;
using server.Models.Enums;

namespace server.Models.Games;

public class Game : BaseModel
{
    [Required]
    [MinLength(3, ErrorMessage = "Минимальная длинна 3 символов")]
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }

    [Required]
    public GameCategory GameCategory { get; set; }
}