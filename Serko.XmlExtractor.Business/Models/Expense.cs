using Serko.XmlExtractor.Business.Services;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Serko.XmlExtractor.Business.Models
{
    [XmlRoot(ElementName = "expense")]
    public class Expense
    {
        [XmlElement(ElementName = "cost_centre")]
        public string CostCentre { get; set; }

        [XmlElement(ElementName = "total")]
        public decimal? Total { get; set; }

        [XmlElement(ElementName = "payment_method")]
        public string PaymentMethod { get; set; }
    }
}
