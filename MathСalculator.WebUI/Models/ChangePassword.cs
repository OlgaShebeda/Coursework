using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MathСalculator.WebUI.Models
{
    public class ChangePassword
    {
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "This fiels must be less the {1} symbols")]
        [Display(Name = "Cтарый пароль")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Пароль должен содержать не меньше 6 символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}