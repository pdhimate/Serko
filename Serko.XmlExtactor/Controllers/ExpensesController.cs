using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serko.XmlExtractor.Business.DTOs;
using Serko.XmlExtractor.Business.Services;

namespace Serko.XmlExtactor.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ExpensesController : Controller
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
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
            return Ok(report);
        }

    }
}
