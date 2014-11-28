using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TheArtOfUnitTesting.IndirectionLayer;

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
        public void IsValidLogFileName_UsingStubConstructor()
        {
            var fakeManager = new StubExtensionManager();
            fakeManager.ShouldExtensionBeValid = true;

            m_analyzer = new LogAnalyzer(fakeManager);
            bool result =  m_analyzer.IsValidLogFileName("test.tat");
            Assert.IsTrue(result);
         }

        [Test]
        public void IsValidLogFileName_UsingStubProperty()
        {
            var fakeManager = new StubExtensionManager();
            fakeManager.ShouldExtensionBeValid = true;

            m_analyzer = new LogAnalyzer();
            //set manager to use stub using Property
            m_analyzer.ExtensionManager = fakeManager;

            bool result = m_analyzer.IsValidLogFileName("test.tat");
            Assert.IsTrue(result);
        }


        [Test]
        public void IsValidLogFileName_UsingFactoryClass()
        {
            var fakeManager = new StubExtensionManager();
            fakeManager.ShouldExtensionBeValid = true;

            //configuring factory before creating required object
            ExtenstionManagerFactory.SetManager(fakeManager);

            m_analyzer = new LogAnalyzer();
           
            bool result = m_analyzer.IsValidLogFileName("test.tat");
            Assert.IsTrue(result);
        }

        [TearDown]
        public void CleanUp()
        {
            m_analyzer = null;
        }
    }
}
