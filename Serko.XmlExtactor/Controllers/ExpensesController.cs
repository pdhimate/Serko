using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serko.XmlExtractor.Business.Services;

namespace Serko.XmlExtactor.Controllers
{
    [Route("api/[controller]")]
    public class ExpensesController : Controller
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        // POST api/expenses
        [HttpPost]
        public IActionResult Post([FromBody]string textWithXml)
        {
            var report = _expenseService.GetExpenseReport(textWithXml);
            return Ok(report);
        }

    }
}
