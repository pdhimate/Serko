using Serko.XmlExtractor.Business.DTOs;
using Serko.XmlExtractor.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace Serko.XmlExtractor.Business.Services
{
    public class ExpenseService
    {
        #region Dependencies

        private readonly IXmlService _xmlService;

        #endregion

        #region Constants

        const decimal GSTPercent = 15;
        const string UnknownVendorName = "UNKNOWN";

        // XML Tags
        const string ExpenseTag = "expense";
        const string TotalTag = "total";
        const string VendorTag = "vendor";
        const string DescriptionTag = "description";
        const string DateTag = "date";

        #endregion

        public ExpenseService(IXmlService xmlService)
        {
            _xmlService = xmlService;
        }

        public ExpenseReport GetExpenseReport(string text)
        {
            // Get expense and GST amount
            var expense = ExtractExpenseMarkup(text);
            var gstAmount = CalculateGSTAmount(expense.Total.Value);

            // Prepare the report
            var report = new ExpenseReport
            {
                Expense = expense,
                Vendor = _xmlService.ExtractXmlIsland(text, VendorTag),
                Description = _xmlService.ExtractXmlIsland(text, DescriptionTag),
            };

            // Parse Date, if any, and update it in the report
            var dateXml = _xmlService.ExtractXmlIsland(text, DateTag);
            if (DateTime.TryParse(dateXml, out DateTime date))
            {
                report.Date = date;
            }

            return report;
        }


        #region Local helpers

        private Expense ExtractExpenseMarkup(string text)
        {
            // Fetch Expense
            var expenseXml = _xmlService.ExtractXmlIsland(text, ExpenseTag);
            if (expenseXml == null)
            {
                throw new InvalidDataException($"The provided text does not contain the XML tag for <{ExpenseTag}>.");
            }
            var expense = _xmlService.TryDeserialize<Expense>(expenseXml);
            if (expense == null)
            {
                throw new InvalidDataException($"The provided text does not contain a valid XML Markup for <{ExpenseTag}>.");
            }

            // Sanitize/Validate
            if (!expense.Total.HasValue)
            {
                throw new InvalidDataException($"The provided text does `not contain the XML tag for <{TotalTag}> or its value is empty");
            }
            if (expense.CostCentre == null)
            {
                expense.CostCentre = UnknownVendorName;
            }

            return expense;
        }

        private decimal CalculateGSTAmount(decimal totalWithGst)
        {
            return (totalWithGst * 100M) / (100M + GSTPercent);
        }

        #endregion
    }
}
