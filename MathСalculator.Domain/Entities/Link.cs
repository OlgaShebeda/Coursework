using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MathСalculator.Domain.Entities
{
    public class Link
    {
        [Key]
        public string Name { get; set; }
        public string Url { get; set; }
        public string NameController { get; set; }
        public string NameImage { get; set; }
    }
}
