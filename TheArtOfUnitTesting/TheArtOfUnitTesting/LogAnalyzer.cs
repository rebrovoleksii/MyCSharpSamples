using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheArtOfUnitTesting.IndirectionLayer;
using TheArtOfUnitTesting.Service;

namespace TheArtOfUnitTesting
{
    public class LogAnalyzer
    {
        #region Fields and Props
       
        private IExtensionManager manager;
        private IWebService service;
        private IEmailService email;

        //property dependency injection
        public IExtensionManager ExtensionManager 
        {
            get { return manager; }
            set { manager = value; } 
        }

        #endregion Fields and Props

        #region cctors
        //using Factory to ontain object
        public LogAnalyzer()
        {
            manager = ExtenstionManagerFactory.Create();
        }

        // constructor level injection
        public LogAnalyzer(IExtensionManager mgr)
        {
            manager = mgr;
        }

        // constructor with service
        public LogAnalyzer(IWebService service = null,IEmailService email=null)
        {
            this.service = service;
            this.email = email;
        }

        #endregion

        public bool IsValidLogFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("No filenameprovided!");
            }
            return manager.isValid(fileName);
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8){
                try {
                    service.LogError("Following file name is too short - " + fileName);
                }
                catch (Exception e) {
                    email.SendMail("Admin","ErrorLogged",e.Message);
                }
                    
            }

        }
     }

    #region Classes for example with event

    public class IView { public event EventHandler Load;}

    public class Presenter
    {
        IView view;

        public Presenter(IView view)
        {
            this.view = view;
            this.view.Load += new EventHandler(view_Load);
        }

        void view_Load(object sender, EventArgs e)
        { throw new NotImplementedException(); }
    }

    #endregion Classes for example with event
}
