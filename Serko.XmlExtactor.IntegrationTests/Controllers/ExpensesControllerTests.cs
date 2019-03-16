using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Serko.XmlExtractor.Business.DTOs;
using System.Net;

namespace Serko.XmlExtactor.IntegrationTests.Controllers
{
    [TestClass]
    public class ExpensesControllerTests : TestsBase
    {
        private const string _apiurl = "api/expenses";

        #region POST

        [TestMethod]
        public void Post_TextWithValidXml_Returns_Report()
        {
            var req = new ExpenseReportReq
            {
                TextWithXml = Resources.TextWithValidXml
            };
            var request = new RestRequest(_apiurl, Method.POST);
            request.AddJsonBody(req);
            var res = RestClient.Execute<ExpenseReport>(request);

            Assert.AreEqual(1024.01M, res.Data.Expense.Total);
            Assert.AreEqual("personal card", res.Data.Expense.PaymentMethod);
            Assert.AreEqual("DEV002", res.Data.Expense.CostCentre);
        }

        #endregion
    }
}
