using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLibrary
{
    public class PeopleRepository
    {
        public string [] GetPeopleList()
        {
            return new string[3] { "John Dow","Jane Dow", "Jogh Galt"};
        }

        public List<string> GetPeopleListNew()
        {
            return new List<string>() { "John Dow", "Jane Dow", "Jogh Galt" };
        }
    }
}
