using System.ComponentModel.DataAnnotations;

namespace server.Models.Requests;

public class RegisterRequestModel
{
    [Required(ErrorMessage = "Укажите логин")]
    [MaxLength(20, ErrorMessage = "Логин не должен превышать 20 символов")]
    [MinLength(3, ErrorMessage = "Логин должен быть более 3 символов")]
    public string Login { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Укажите пароль")]
    [MaxLength(6, ErrorMessage = "Пароль должен быть минимум 6 символов")]
    public string Password { get; set; }
    
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Подтвердите пароль")]
    [Compare("Password", ErrorMessage = "Пароль не совпадает")]
    public string PasswordConfrim { get; set; }
}