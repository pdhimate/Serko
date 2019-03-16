using Serko.XmlExtractor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serko.XmlExtractor.Business.DTOs
{
    public class ExpenseReport 
    {
        public Expense Expense { get; set; }

        public string Vendor { get; set; }
        public string Description { get; set; }
        public string Date { get; set; } // Convert to DateTime?
    }
}
