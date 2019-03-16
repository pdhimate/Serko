using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serko.XmlExtractor.Business.Services;

namespace Serko.XmlExtractor.Business.Tests.Services
{
    [TestClass]
    public class ExpenseServiceTests
    {
        #region Constants

        [TestMethod]
        public void Gst_Is_15Percent()
        {
            Assert.AreEqual(15, ExpenseService.GSTPercent);
        }

        #endregion

        #region IExpenseService implementation

        [TestMethod]
        public void GetExpenseReport_PeparesAndReturnsReport()
        {
            // Setup XML service
            var xmlService = new Mock<IXmlService>();
            xmlService.Setup(m => m.ExtractXmlIsland(It.IsAny<string>(), ExpenseService.VendorTag)).Returns("Viaduct Steakhouse");
            xmlService.Setup(m => m.ExtractXmlIsland(It.IsAny<string>(), ExpenseService.DescriptionTag)).Returns("development team’s project end celebration dinner");
            xmlService.Setup(m => m.ExtractXmlIsland(It.IsAny<string>(), ExpenseService.DateTag)).Returns("Tuesday 27 April 2017");

            // Setup expense service
            var expenseService = GetMockedService(xmlService);
            expenseService.Setup(m => m.ExtractExpenseMarkup(It.IsAny<string>())).Returns(new Models.Expense
            {
                CostCentre = "DEV002",
                PaymentMethod = "personal card",
                Total = 115
            });
            expenseService.Setup(m => m.CalculateGSTAmount(It.IsAny<decimal>())).Returns(15);

            // Get report
            var report = expenseService.Object.GetExpenseReport(It.IsAny<string>());

            Assert.IsNotNull(report);
        }

        #endregion

        #region Local helpers

        #region CalculateGSTAmount

        [TestMethod]
        public void CalculateGSTAmount_For0Total_Returns0GstAmount()
        {
            var xmlService = new Mock<IXmlService>();
            var expenseService = GetMockedService(xmlService);

            var totalWithGst = 0;
            var gstAmount = expenseService.Object.CalculateGSTAmount(totalWithGst);

            Assert.AreEqual(0, gstAmount);
        }

        [TestMethod]
        public void CalculateGSTAmount_For1024Point01Total_Returns0GstAmount()
        {
            var xmlService = new Mock<IXmlService>();
            var expenseService = GetMockedService(xmlService);

            var totalWithGst = 1024.01M;
            var gstAmount = expenseService.Object.CalculateGSTAmount(totalWithGst);

            Assert.AreEqual(890.4434782608695652173913043M, gstAmount);
        }

        #endregion

        #endregion

        private static Mock<ExpenseService> GetMockedService(Mock<IXmlService> xmlService)
        {
            return new Mock<ExpenseService>(new object[] { xmlService.Object }) { CallBase = true };
        }
    }
}
