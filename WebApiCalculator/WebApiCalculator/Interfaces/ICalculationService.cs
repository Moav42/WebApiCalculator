using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCalculator.Models;

namespace WebApiCalculator.Interfaces
{
    public interface ICalculationService
    {
        CalculationModel CalculateOperationResult(CalculationModel calculationModel);     
    }
}
