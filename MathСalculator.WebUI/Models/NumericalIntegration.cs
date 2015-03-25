using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MathСalculator.WebUI.Models
{
    public class NumericalIntegration
    {
        [Required]
        [Display(Name = "Введите функцию f(x)")]
        public string Function { get; set; }

        [Display(Name = "Введите начало отрезка интегрирования [a,b]")]
        public double A { get; set; }
        [Display(Name = "Введите конец отрезка интегрирования [a,b]")]
        public double B { get; set; }

        [Display(Name = "Введите число разбиения отрезка")]
        public int N { get; set; }
        public double Result { get; set; }
    }
}