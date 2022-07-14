using System.ComponentModel.DataAnnotations;

namespace server.Models.Enums;

public enum Role
{
    [Display(Name = "Пользователь")]
    User,
    [Display(Name = "Модератор")]
    Moderator,
    [Display(Name = "Администратор")]
    Admin
}