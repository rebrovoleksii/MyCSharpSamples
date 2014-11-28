using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheArtOfUnitTesting
{
    class FileExtensionManager:IExtensionManager
    {
        public bool isValid(string fileName)
        {
            if (!fileName.ToLower().EndsWith(".slf"))
            {
                return false;
            }
            return true;
        }
    }
}
