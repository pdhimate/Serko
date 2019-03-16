using Serko.XmlExtractor.Business.DTOs;

namespace Serko.XmlExtractor.Business.Services
{
    public interface IExpenseService
    {
        ExpenseReport GetExpenseReport(ExpenseReportReq req);
    }
}