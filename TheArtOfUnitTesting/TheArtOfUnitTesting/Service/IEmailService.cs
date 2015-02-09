using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheArtOfUnitTesting.Service
{
    public interface IEmailService
    {
        void SendMail(string to, string subj, string body);
    }
}
