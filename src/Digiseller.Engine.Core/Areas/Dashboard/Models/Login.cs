using System.ComponentModel.DataAnnotations;

namespace Digiseller.Engine.Core.Areas.Dashboard.Models
{
    public class LoginModel
    {
        [Display(Name = "Логин")]
        [Required]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [MinLength(8)]
        [Required]
        public string Password { get; set; }
    }
}
