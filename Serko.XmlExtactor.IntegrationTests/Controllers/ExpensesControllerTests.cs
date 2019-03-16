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
        public void Post_WithNullText_Returns_HttpbadRequest()
        {
            var req = new ExpenseReportReq
            {
                TextWithXml = null
            };
            var request = new RestRequest(_apiurl, Method.POST);
            request.AddJsonBody(req);
            var res = RestClient.Execute(request);

            Assert.AreEqual(HttpStatusCode.BadRequest, res.StatusCode);
        }

        [TestMethod]
        public void Post_TextWithMissingTotal_Returns_HttpNotFound()
        {
            var req = new ExpenseReportReq
            {
                TextWithXml = Resources.TextWithMissingTotal
            };
            var request = new RestRequest(_apiurl, Method.POST);
            request.AddJsonBody(req);
            var res = RestClient.Execute(request);

            Assert.AreEqual(HttpStatusCode.NotFound, res.StatusCode);
        }

        [TestMethod]
        public void Post_TextWithMissingCostCentre_Returns_ReportWithUnknownCostCentre()
        {
            var req = new ExpenseReportReq
            {
                TextWithXml = Resources.TextWithMissingCostCentre
            };
            var request = new RestRequest(_apiurl, Method.POST);
            request.AddJsonBody(req);
            var res = RestClient.Execute<ExpenseReport>(request);

            Assert.AreEqual("UNKNOWN", res.Data.Expense.CostCentre);
        }

        [TestMethod]
        public void Post_TextWithInvalidXml_Returns_HttpBadRequest()
        {
            var req = new ExpenseReportReq
            {
                TextWithXml = Resources.TextWithInvalidXml
            };
            var request = new RestRequest(_apiurl, Method.POST);
            request.AddJsonBody(req);
            var res = RestClient.Execute(request);

            Assert.AreEqual(HttpStatusCode.BadRequest, res.StatusCode);
        }

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
            Assert.AreEqual("Tuesday 27 April 2017", res.Data.Date);
            Assert.AreEqual("development team’s project end celebration dinner", res.Data.Description);
            Assert.AreEqual("Viaduct Steakhouse", res.Data.Vendor);
        }

        #endregion
    }
}
