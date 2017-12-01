using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using People.CSVRepository;

namespace Interface.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var type = typeof(CSVRepository).FullName;
        }
    }
}
