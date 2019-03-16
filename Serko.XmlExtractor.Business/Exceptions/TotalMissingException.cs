using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Serko.XmlExtractor.Business.Exceptions
{
    /// <summary>
    /// Represents an exception where the Total tag was not found
    /// </summary>
    public class TotalMissingException : BusinessException
    {
        public TotalMissingException(string message) : base(message)
        {
        }

        public override HttpStatusCode GetHttpCode()
        {
            return HttpStatusCode.NotFound;
        }
    }



}
