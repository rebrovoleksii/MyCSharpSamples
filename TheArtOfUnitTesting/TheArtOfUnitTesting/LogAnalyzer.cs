using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheArtOfUnitTesting
{
    class LogAnalyzer
    {
        private IExtensionManager manager;

        public LogAnalyzer()
        {
            manager = new FileExtensionManager();
        }

        public LogAnalyzer(IExtensionManager mgr)
        {
            manager = mgr;
        }
        
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
