using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializationExamples
{
    public class Account
    {
        private string username;
        private int id;
        
        public string UserName { 
            get 
            {
                return username;
            }
            set
            {
                username=value;
            }
        }
        public int AccountId { 
            get 
            {
                return id;
            }
            set
            {
                id=value;
            } 
        }

        public Account()
        {
            UserName = "Alex";
            AccountId = 13464500;
        }

    }
}
