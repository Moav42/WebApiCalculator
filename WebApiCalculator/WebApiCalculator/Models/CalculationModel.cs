using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCalculator.Models
{
    public class CalculationModel
    {
        [Required]
        public double FirstNumber { get; set; }

        [Required]
        public string OperationSign { get; set; }

        [Required]
        public double SecondNumber { get; set; }

        public double Result { get; set; }
 
    }
}
