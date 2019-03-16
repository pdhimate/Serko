using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Serko.XmlExtractor.Business.DTOs
{
    public class ExpenseReportReq
    {
        [Required]
        public string TextWithXml { get; set; }
    }
}
