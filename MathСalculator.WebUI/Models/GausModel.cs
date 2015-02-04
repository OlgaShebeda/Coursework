using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MathСalculator.WebUI.Models
{
    public class GausModel
    {
        [Display(Name = "Столбец свободных членов")]
        public double[] myArray { get; set; }

        public double[] answer { get; set; }

        [Display(Name = "Матрица коэфициентов")]
        public double[,] Matrix { get; set; }

        [Display(Name = "Количество переменных")]
        public int countVariable { get; set; }

        [Display(Name = "Количество строк")]
        public int countRows { get; set; }
    }
}