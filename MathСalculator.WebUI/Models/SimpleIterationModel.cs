using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MathСalculator.WebUI.Models
{
    public class SimpleIterationModel
    {
        [Display(Name = "Введите функцию")]
        public string Fuctions { get; set; }
        public double Result { get; set; }
        public double X0 {get; set;}
        public double Epsilon { get; set; }
    }
}