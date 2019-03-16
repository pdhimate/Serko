using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Serko.XmlExtractor.Business.Exceptions
{
    public class InvalidExpenseException : BusinessException
    {
        public InvalidExpenseException(string message) : base(message)
        {
        }

        public override HttpStatusCode GetHttpCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}
