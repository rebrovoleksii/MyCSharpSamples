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
        private LogAnalyzer m_analyzer;

        [SetUp]
        public void Setup()
        {
            m_analyzer = new LogAnalyzer();
        }

        [Test]
        public void IsValidFileName_validFileLowerCase_ReturnsTrue()
        {
            var res = m_analyzer.IsValidLogFileName("firsttest.slf");
            Assert.IsTrue(res,"file name should be valid");
        }
        
        [Test]
        public void IsValidFileName_validFileUpperCase_ReturnsTrue()
        {
            var res = m_analyzer.IsValidLogFileName("firsttest.SLF");
            Assert.IsTrue(res, "file name should be valid");
        }

        [Category("Fast Test")]
        [ExpectedException(typeof(ArgumentException),ExpectedMessage="No filenameprovided!")]
        [Test]
        public void ArgumentExceptionTest()
        {
            m_analyzer.IsValidLogFileName(String.Empty);
        }

        [Ignore("that's example of ignored test")]
        [Test]
        public void IgnoredTest()
        {
            return;
        }

        [Test]
        public void IsValidLogFileName_UsingStub()
        {
            var fakeManager = new StubExtensionManager();
            fakeManager.ShouldExtensionBeValid = true;

            m_analyzer = new LogAnalyzer(fakeManager);
            bool result =  m_analyzer.IsValidLogFileName("test.tat");
            Assert.IsTrue(result);
         }

        [TearDown]
        public void CleanUp()
        {
            m_analyzer = null;
        }
    }
}
