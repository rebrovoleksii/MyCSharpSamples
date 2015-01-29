using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheArtOfUnitTesting.IndirectionLayer;

namespace TheArtOfUnitTesting
{
    public class LogAnalyzer
    {
        #region Fields and Props
       
        private IExtensionManager manager;
        private IWebService service;

        //property dependency injection
        public IExtensionManager ExtensionManager 
        {
            get { return manager; }
            set { manager = value; } 
        }

        #endregion Fields and Props

        #region cctors
        //using Factory to ontain object
        public LogAnalyzer()
        {
            manager = ExtenstionManagerFactory.Create();
        }

        // constructor level injection
        public LogAnalyzer(IExtensionManager mgr)
        {
            manager = mgr;
        }

        // constructor with service
        public LogAnalyzer(IWebService service)
        {
            this.service = service;
        }

        #endregion

        public bool IsValidLogFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("No filenameprovided!");
            }
            return manager.isValid(fileName);
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8){
                service.LogError("Following file name is too short - " + fileName);
            }
        }
     }
}
