using System.ComponentModel.DataAnnotations;

namespace server.Models.Enums;

public enum GameCategory
{
    [Display(Name = "Экшен")]
    Action,
    [Display(Name = "Приключения")]
    Adventure,
    [Display(Name = "Хорор")]
    Horror,
    [Display(Name = "Спорт")]
    Sport
}