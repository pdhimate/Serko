using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serko.XmlExtractor.Business.Models;
using Serko.XmlExtractor.Business.Services;

namespace Serko.XmlExtractor.Business.Tests.Services
{
    [TestClass]
    public class XmlServiceTests
    {
        #region TryDeserialize

        [TestMethod]
        public void TryDeserialize_ForInvalidXML_ReturnsNull()
        {
            var service = GetMockedService();
            var expense = service.Object.TryDeserialize<Expense>(Resources.InvalidXml);

            Assert.IsNull(expense);
        }

        [TestMethod]
        public void TryDeserialize_ForValidXML_ReturnsObject()
        {
            var service = GetMockedService();
            var expense = service.Object.TryDeserialize<Expense>(Resources.ValidXml);

            Assert.IsNotNull(expense);
        }

        [TestMethod]
        public void TryDeserialize_Expense_ForMissingTotal_ReturnsNullTotal()
        {
            var service = GetMockedService();
            var expense = service.Object.TryDeserialize<Expense>(Resources.XmlWithMissingTotal);

            Assert.AreEqual(null, expense.Total);
        }

        [TestMethod]
        public void TryDeserialize_Expense_ForMissingCostCentre_ReturnsUnknown()
        {
            var service = GetMockedService();
            var expense = service.Object.TryDeserialize<Expense>(Resources.XmlWithMissingCostCentre);

            Assert.AreEqual("UNKNOWN", expense.CostCentre);
        }


        #endregion

        private static Mock<XmlService> GetMockedService()
        {
            return new Mock<XmlService>() { CallBase = true };
        }

    }
}
