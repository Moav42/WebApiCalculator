using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCalculator.Interfaces;
using WebApiCalculator.Models;

namespace WebApiCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        public readonly ICalculationService _calculationService;

        public CalculatorController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(CalculationModel calculationModel)
        {
            try
            {
                _calculationService.CalculateOperationResult(calculationModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            await _calculationService.WriteCalculationLogAsync(calculationModel);

            return Ok(calculationModel.Result);
        }

        [HttpGet("log")]
        public async Task<IActionResult> GetCalculationLog(string operationSign)
        {
            string log;

            if (String.IsNullOrEmpty(operationSign))
            {
                log = await _calculationService.ReadCalculationLogAsync();
            }
            else
            {
                log = await _calculationService.ReadCalculationLogFilteredByOperationSignAsync(operationSign);
            }

            return Ok(log);
        }
    }
}