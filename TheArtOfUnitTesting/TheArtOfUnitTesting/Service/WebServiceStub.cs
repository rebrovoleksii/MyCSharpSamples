using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheArtOfUnitTesting.Service
{
    public class WebServiceStub:IWebService
    {
        public string lastError;
        public void LogError(String message)
        {
            lastError = message;
        }        
    }

    public class WebServiceWithExceptionStub : IWebService
    {
        public void LogError(String message)
        {
            throw new Exception("exception");
        }
    }
}
