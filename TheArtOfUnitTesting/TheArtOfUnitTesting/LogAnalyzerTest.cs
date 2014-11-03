using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TheArtOfUnitTesting
{
    [TestFixture]
    class LogAnalyzerTest
    {
        [Test]
        public void IsValidFileName_validFile_ReturnsTrue()
        {
            var logAnalyzer = new LogAnalyzer();
            var res = logAnalyzer.IsValidLogFileName("firsttest.SLF");
            Assert.IsTrue(res,"file name should be valid");
        }
    }
}
