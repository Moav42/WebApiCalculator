using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCalculator.Exceptions
{
    public class CalculationExceptions : Exception
    {
        public CalculationExceptions(string message) : base(message)
        {
        }
    }
}
