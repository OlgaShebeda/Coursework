using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MathСalculator.WebUI.Models
{
    public class RectanglesIntegration
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

        [Required]
        public double Result { get; set; }
        [Required]
        public string Method { get; set; }
    }
}