using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCalculator.Exceptions;
using WebApiCalculator.Interfaces;
using WebApiCalculator.Models;

namespace WebApiCalculator.Services
{
    public class CalculationService : ICalculationService
    {
        public CalculationModel CalculateOperationResult(CalculationModel calculationModel)
        {
            calculationModel.Result = calculationModel.OperationSign switch
            {
                "+" => calculationModel.FirstNumber + calculationModel.SecondNumber,
                "-" => calculationModel.FirstNumber - calculationModel.SecondNumber,
                "*" => calculationModel.FirstNumber * calculationModel.SecondNumber,
                "/" => calculationModel.FirstNumber / calculationModel.SecondNumber,
                _ => throw new CalculationExceptions("This operator is not supported"),
            };

            return calculationModel;
        }      
    }
}
