using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCalculator.Exceptions;
using WebApiCalculator.Interfaces;
using WebApiCalculator.Models;

namespace WebApiCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculationService _calculationService;
        private readonly ICalculationLoggingService _calculationLoggingService;

        public CalculatorController(ICalculationService calculationService, ICalculationLoggingService calculationLoggingService)
        {
            _calculationService = calculationService;
            _calculationLoggingService = calculationLoggingService;
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(CalculationModel calculationModel)
        {
            try
            {
                _calculationService.CalculateOperationResult(calculationModel);
            }
            catch (CalculationExceptions ex)
            {
                return BadRequest(ex.Message);
            }

            await _calculationLoggingService.WriteCalculationLogAsync(calculationModel);

            return Ok(calculationModel);
        }

        [HttpGet("log")]
        public async Task<IActionResult> GetCalculationLog(string operationSign)
        {
            string log;

            if (String.IsNullOrEmpty(operationSign))
            {
                log = await _calculationLoggingService.ReadCalculationLogAsync();
            }
            else
            {
                log = await _calculationLoggingService.ReadCalculationLogFilteredByOperationSignAsync(operationSign);
            }

            return Ok(log);
        }
    }
}