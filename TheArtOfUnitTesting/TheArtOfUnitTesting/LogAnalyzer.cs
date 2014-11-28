using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheArtOfUnitTesting.IndirectionLayer;

namespace TheArtOfUnitTesting
{
    class LogAnalyzer
    {
        #region Fields and Props
       
        private IExtensionManager manager;

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

        // constructoer level injection
        public LogAnalyzer(IExtensionManager mgr)
        {
            manager = mgr;
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
     }
}
