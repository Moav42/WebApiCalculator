﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCalculator.Interfaces;
using WebApiCalculator.Models;

namespace WebApiCalculator.Services
{
    public class CalculationService : ICalculationService
    {
        string calculationLogPath = "./CalculationLog.text";

        public CalculationModel CalculateOperationResult(CalculationModel calculationModel)
        {
            calculationModel.Result = calculationModel.OperationSign switch
            {
                "+" => calculationModel.FirstNumber + calculationModel.SecondNumber,
                "-" => calculationModel.FirstNumber - calculationModel.SecondNumber,
                "*" => calculationModel.FirstNumber * calculationModel.SecondNumber,
                "/" => calculationModel.FirstNumber / calculationModel.SecondNumber,
                _ => throw new Exception("This operator is not supported"),
            };

            return calculationModel;
        }

        public async Task WriteCalculationLogAsync(CalculationModel calculationModel)
        {
            using (var sw = new StreamWriter(calculationLogPath, true))
            {
                await sw.WriteLineAsync($"Operation {calculationModel.FirstNumber} {calculationModel.OperationSign}" +
                          $" {calculationModel.SecondNumber} = {calculationModel.Result} " +
                          $"was executed on {DateTime.Now.ToLongDateString()}, at {DateTime.Now.ToShortTimeString()}");
            }
        }

        public async Task<string> ReadCalculationLogAsync()
        {
            return await File.ReadAllTextAsync(calculationLogPath);
        }

        public async Task<string> ReadCalculationLogFilteredByOperationSignAsync(string operationSign)
        {
            string[] allLogLines = await File.ReadAllLinesAsync(calculationLogPath);

            StringBuilder filteredLogs = new StringBuilder();
            foreach (var line in allLogLines)
            {
                if (line.Contains(operationSign))
                {
                    filteredLogs.Append(line +"\n");
                }
            }

            return filteredLogs.ToString();
        }
    }
}
