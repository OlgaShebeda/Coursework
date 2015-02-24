using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MathСalculator.WebUI.Models
{
    public class SimpleIterationModel
    {
        [Required]
        [Display(Name = "Введите функцию")]
        public string Fuctions { get; set; }

        [Display(Name = "Результат")]
        public double Result { get; set; }

        [Display(Name = "Начальное приближение")]
         public double X0 {get; set;}

        [Display(Name = "Епсилон")]
        public double Epsilon { get; set; }

        [Display(Name = "Проверка на устойчивость")] public bool Chek;
    }
}

