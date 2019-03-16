using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Serko.XmlExtractor.Business.Exceptions
{
    /// <summary>
    /// Represents a Generic business layer exception
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }

        public virtual HttpStatusCode GetHttpCode()
        {
            // The default HTTP code for a business exception
            return HttpStatusCode.BadRequest;
        }
    }
}
