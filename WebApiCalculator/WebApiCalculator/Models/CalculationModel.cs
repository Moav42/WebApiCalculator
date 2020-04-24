using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCalculator.Models
{
    public class CalculationModel
    {
        public double FirstNumber { get; set; }
        public string OperationSign { get; set; }
        public double SecondNumber { get; set; }
        public double Result { get; set; }
 
    }
}
