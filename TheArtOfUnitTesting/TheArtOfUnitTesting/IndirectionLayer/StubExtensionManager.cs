using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheArtOfUnitTesting
{
    public class StubExtensionManager : IExtensionManager
    {
        public bool ShouldExtensionBeValid;

        public bool isValid(string fileName)
        {
            return ShouldExtensionBeValid;
        }
    }
}
