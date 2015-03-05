using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MathСalculator.WebUI.Models
{
    public class GCDModel
    {
        public int firstNumber { get; set; }
        public int secondNumber { get; set; }
        public int? result { get; set; }
    }
}