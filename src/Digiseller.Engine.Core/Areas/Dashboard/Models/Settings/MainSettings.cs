using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Digiseller.Engine.Core.Areas.Dashboard.Models.Settings
{
    public class MainSettings
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Наименование магазина")]
        public string ShopName { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Ключевые слова (Keywords) для сайта")]
        public string KeyWords { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Описание (Description) сайта")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Количество товаров на странице")]
        public uint CountOfGoodsPerPage { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Выключить сайт")]
        public bool IsOffline { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Причина отключения сайта")]
        public string OfflineMessage { get; set; }

        public bool Installed { get; set; } = true;
    }

    public class AdminSettings
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Новый пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Повторите новый пароль")]
        [JsonIgnore]
        public string PasswordCompare { get; set; }
    }

    public class DigisellerSettings
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Идентификатор продавца (числовой)")]
        public uint DigisellerId { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Display(Name = "Идентификатор продавца (строковый)")]
        public string DigisellerUid { get; set; }
    }
}
