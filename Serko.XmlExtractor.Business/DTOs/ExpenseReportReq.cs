using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Serko.XmlExtractor.Business.DTOs
{
    public class ExpenseReportReq
    {
        /// <summary>
        /// Text containing XML markup/islands which define an expense.
        /// </summary>
        [Required]
        public string TextWithXml { get; set; }
    }
}
