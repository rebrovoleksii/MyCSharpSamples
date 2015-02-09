using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheArtOfUnitTesting.Service
{
    public class EmailServiceStub : IEmailService
    {
        #region Props

        private string recipient;
        private string subject;
        private string messagebodu;
        
        #endregion Props

        void IEmailService.SendMail(string to, string subj, string body)
        {
            recipient = to;
            subject = subj;
            messagebodu = body;
        }

        public bool ValidateSendMail(string expTo, string expSubj, string expBody)
        { 
            return (expTo==this.recipient)&&(expSubj==this.subject)&&(expBody==this.messagebodu);
        }

    }
}
