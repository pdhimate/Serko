using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Serko.XmlExtractor.Business.DTOs;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Serko.XmlExtactor.IntegrationTests.Controllers
{
    [TestClass]
    public class ExpensesControllerTests : TestsBase
    {
        private string _apiurl = $"{ApiHostBaseUrl}api/expenses";

        #region POST

        [TestMethod]
        public async Task Post_TextWithValidXml_ReturnsReportAsync()
        {
            // Create request
            var req = new ExpenseReportReq
            {
                TextWithXml = Resources.TextWithValidXml
            };
            var jsonReq = JsonConvert.SerializeObject(req);
            var httpContent = new StringContent(jsonReq, Encoding.UTF8, "application/json");
            HttpResponseMessage response;

            // POST
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await client.PostAsync(_apiurl, httpContent);
            }

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        #endregion
    }
}
