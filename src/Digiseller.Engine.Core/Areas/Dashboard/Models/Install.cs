using System.ComponentModel.DataAnnotations;

namespace Digiseller.Engine.Core.Areas.Dashboard.Models
{
    public class Install
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Логин")]
        [MinLength(4, ErrorMessage = "Длина логина должна быть не менее 4 символов!")]
        public string AdminLogin { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Пароль")]
        [MinLength(8, ErrorMessage="Длина пароля должна быть не менее 8 символов!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают! Проверьте правильность ввода.")]
        public string PasswordCompare { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Идентификатор продавца")]
        public uint DigisellerId { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Идентификатор продавца (UID)")]
        public string DigisellerUid { get; set; }
    }
}