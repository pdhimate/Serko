using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serko.XmlExtractor.Business.DTOs;
using Serko.XmlExtractor.Business.Services;

namespace Serko.XmlExtactor.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ExpensesController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly ILogger<ExpensesController> _logger;

        public ExpensesController(IExpenseService expenseService, ILogger<ExpensesController> logger)
        {
            _expenseService = expenseService;
            _logger = logger;
        }

        /// <summary>
        /// Generates an Expense Report based upon the input text containing XML markup/islands
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ExpenseReport), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] ExpenseReportReq req)
        {
            var report = _expenseService.GetExpenseReport(req);
            _logger.LogInformation("Report ready.");
            return Ok(report);
        }

    }
}
