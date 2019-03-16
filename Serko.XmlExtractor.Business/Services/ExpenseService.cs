using Serko.XmlExtractor.Business.DTOs;
using Serko.XmlExtractor.Business.Exceptions;
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
    public class ExpenseService : IExpenseService
    {
        #region Dependencies

        private readonly IXmlService _xmlService;

        #endregion

        #region Constants

        public const decimal GSTPercent = 15;
        public const string UnknownCostCentre = "UNKNOWN";

        // XML Tags
        public const string VendorTag = "vendor";
        public const string DescriptionTag = "description";
        public const string DateTag = "date";
        const string ExpenseTag = "expense";
        const string TotalTag = "total";

        #endregion

        public ExpenseService(IXmlService xmlService)
        {
            _xmlService = xmlService;
        }

        #region IExpenseService implementation

        public ExpenseReport GetExpenseReport(ExpenseReportReq req)
        {
            var text = req.TextWithXml;

            // Get expense and GST amount
            var expense = ExtractExpenseMarkup(text);
            var gstAmount = CalculateGSTAmount(expense.Total.Value);

            // Prepare the report
            var report = new ExpenseReport
            {
                Expense = expense,
                Vendor = _xmlService.ExtractXmlIslandInnerValue(text, VendorTag),
                Description = _xmlService.ExtractXmlIslandInnerValue(text, DescriptionTag),
                Date = _xmlService.ExtractXmlIslandInnerValue(text, DateTag)
            };

            return report;
        }

        #endregion

        #region Local helpers

        public virtual Expense ExtractExpenseMarkup(string text)
        {
            // Fetch Expense
            var expenseXml = _xmlService.ExtractXmlIsland(text, ExpenseTag);
            if (expenseXml == null)
            {
                throw new InvalidExpenseException($"The provided text does not contain the XML tag for <{ExpenseTag}>.");
            }
            var expense = _xmlService.TryDeserialize<Expense>(expenseXml);
            if (expense == null)
            {
                throw new InvalidExpenseException($"The provided text does not contain a valid XML Markup for <{ExpenseTag}>.");
            }

            // Validate total tag
            if (!expense.Total.HasValue)
            {
                throw new TotalMissingException($"The provided text does not contain the XML tag for <{TotalTag}>");
            }

            // Sanitize Cost centre
            if (expense.CostCentre == null)
            {
                expense.CostCentre = UnknownCostCentre;
            }

            return expense;
        }

        public virtual decimal CalculateGSTAmount(decimal totalWithGst)
        {
            return (totalWithGst * 100M) / (100M + GSTPercent);
        }

        #endregion
    }
}
