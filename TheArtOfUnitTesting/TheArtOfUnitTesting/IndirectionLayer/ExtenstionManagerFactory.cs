using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheArtOfUnitTesting.IndirectionLayer
{
    class ExtenstionManagerFactory
    {
        private static IExtensionManager customManager;

        public static IExtensionManager Create()
        {
            if (customManager!=null) return customManager;
            return new FileExtensionManager();
        }

        public static void SetManager(IExtensionManager mgr)
        {
            customManager = mgr;
        }

    }
}
