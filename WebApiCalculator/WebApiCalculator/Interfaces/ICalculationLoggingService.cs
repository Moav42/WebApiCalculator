using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCalculator.Models;

namespace WebApiCalculator.Interfaces
{
    public  interface ICalculationLoggingService
    {
        Task WriteCalculationLogAsync(CalculationModel calculationModel);
        Task<string> ReadCalculationLogAsync();
        Task<string> ReadCalculationLogFilteredByOperationSignAsync(string operationSign);
    }
}
