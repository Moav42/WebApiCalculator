using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCalculator.Models;

namespace WebApiCalculator.Interfaces
{
    public interface ICalculationService
    {
        public CalculationModel CalculateOperationResult(CalculationModel calculationModel);
        Task WriteCalculationLogAsync(CalculationModel calculationModel);       
        Task<string> ReadCalculationLogAsync();
        Task<string> ReadCalculationLogFilteredByOperationSignAsync(string operationSign);
    }
}
