using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serko.XmlExtactor.IntegrationTests
{
    public abstract class TestsBase
    {
        protected const string ApiHostBaseUrl = "http://localhost:50286";
        protected readonly RestClient RestClient = new RestClient(ApiHostBaseUrl);

    }
}
