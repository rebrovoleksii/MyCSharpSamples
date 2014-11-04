using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheArtOfUnitTesting
{
    class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("No filenameprovided!");
            }
            if (!fileName.ToLower().EndsWith(".slf"))
            {
                return false;
            }
            return true;
        }
    }
}
