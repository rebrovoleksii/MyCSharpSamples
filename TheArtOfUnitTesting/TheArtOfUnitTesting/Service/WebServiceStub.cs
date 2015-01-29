using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheArtOfUnitTesting
{
    public class WebServiceStub:IWebService
    {
        public string lastError;
        public void LogError(String message)
        {
            lastError = message;
        }
    }
}
