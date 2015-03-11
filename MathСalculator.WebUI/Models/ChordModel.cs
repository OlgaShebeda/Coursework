using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MathСalculator.WebUI.Models
{
    public class ChordModel
    {
        [Required]
        [Display(Name = "Введите функцию")]
        public string Fuctions { get; set; }

        [Display(Name = "Результат")]
        public double Result { get; set; }

        [Display(Name = "Начальное приближение x0")]
        public double X0 { get; set; }

        [Display(Name = "Начальное приближение x1")]
        public double X1 { get; set; }

        [Display(Name = "Епсилон")]
        public double Epsilon { get; set; }

        [Display(Name = "проверка")]
        public string adress { get; set; }
    }
}