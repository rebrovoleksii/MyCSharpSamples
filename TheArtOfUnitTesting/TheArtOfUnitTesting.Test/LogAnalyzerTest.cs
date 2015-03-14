using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TheArtOfUnitTesting.IndirectionLayer;
using TheArtOfUnitTesting.Service;
using TheArtOfUnitTesting;


namespace TheArtOfUnitTesting.Test
{
    [TestClass]
    public class LogAnalyzerTest
    {
        private LogAnalyzer m_analyzer;

        [TestInitialize]
        public void Setup()
        {
            m_analyzer = new LogAnalyzer();
        }

       [TestMethod]
        public void IsValidFileName_validFileLowerCase_ReturnsTrue()
        {
            var res = m_analyzer.IsValidLogFileName("firsttest.slf");
            Assert.IsTrue(res,"file name should be valid");
        }
        
       [TestMethod]
        public void IsValidFileName_validFileUpperCase_ReturnsTrue()
        {
            var res = m_analyzer.IsValidLogFileName("firsttest.SLF");
            Assert.IsTrue(res, "file name should be valid");
        }

        [TestCategory("Fast Test")]
        [ExpectedException(typeof(ArgumentException),"No filenameprovided!")]
       [TestMethod]
        public void ArgumentExceptionTest()
        {
            m_analyzer.IsValidLogFileName(String.Empty);
        }

        [Ignore]
       [TestMethod]
        public void IgnoredTest()
        {
            return;
        }

       [TestMethod]
        public void IsValidLogFileName_UsingStubConstructor()
        {
            var fakeManager = new StubExtensionManager();
            fakeManager.ShouldExtensionBeValid = true;

            m_analyzer = new LogAnalyzer(fakeManager);
            bool result =  m_analyzer.IsValidLogFileName("test.tat");
            Assert.IsTrue(result);
         }

       [TestMethod]
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


       [TestMethod]
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

       [TestMethod]
       public void Analyze_LogsError_IfFileNameShorterThan8Chars()
       {
           var serviceStub = new WebServiceStub();
           var log = new LogAnalyzer(serviceStub);
           var filename = "abc.txt";
           log.Analyze(filename);
           Assert.AreEqual("Following file name is too short - "+filename,serviceStub.lastError);

       }

       [TestMethod]
       public void Analyze_SendEmail_WhenExceptionOccursOnLogging()
       {
           var emailStub = new EmailServiceStub();
           var webStub = new WebServiceWithExceptionStub();
           var log = new LogAnalyzer(webStub, emailStub);
           var filename = "test"; 
           log.Analyze(filename);
           Assert.IsTrue(emailStub.ValidateSendMail("Admin", "ErrorLogged", "exception"));

       }

       [TestMethod]
       public void Analyze_TooShortFileName_ErrorLoggedTpServiceWithStrickMock()
       {
           var mocks = new MockRepository();
           IWebService mockService = mocks.StrictMock<IWebService>();

           using (mocks.Record())
           {
               mockService.LogError("Following file name is too short - abc.txt");
           }

           var log = new LogAnalyzer(mockService);
           string shortFileName = "abc.txt";
           log.Analyze(shortFileName);

           mocks.Verify(mockService);

       }

       [TestMethod]
       public void Analyze_TooShortFileName_ErrorLoggedTpServiceWithNonStrickMock()
       {
           var mocks = new MockRepository();
           IWebService mockService = mocks.DynamicMock<IWebService>();

           using (mocks.Record())
           {
               mockService.LogError("Invalid expectation");
           }

           var log = new LogAnalyzer(mockService);
           string shortFileName = "abc.txt";
           log.Analyze(shortFileName);

           mocks.Verify(mockService);

       }

       [TestMethod]
       public void TriggerAndVerifyViewEvents()
       {
           //ARRANGE
           MockRepository mocks = new MockRepository();
           IWebService serviceMock = mocks.StrictMock<IWebService>();
           using (mocks.Record())
           {
               //here we specify expectation
               //since we define handler for Load event
               serviceMock.LogError(EventArgs.Empty.ToString());
           }
           var p = new Presenter(serviceMock);
           p.Load += new EventHandler((object o, EventArgs arg) => {
               serviceMock.LogError(arg.ToString());
           }
               );

           //ACT
           p.OnLoad(EventArgs.Empty);
        
           //ASSERT
           mocks.VerifyAll();
       }
 
       [TestCleanup]
       public void CleanUp()
        {
            m_analyzer = null;
        }
    }
}
