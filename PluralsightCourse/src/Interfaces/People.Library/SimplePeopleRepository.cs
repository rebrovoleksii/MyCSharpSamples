using System.Collections.Generic;
using People.Core;

namespace People.Library
{
    public class SimplePeopleRepository : IPeopleRepository
    {
        public IEnumerable<string> GetPeopleList()
        {
            return new string[3] { "John Dow","Jane Dow", "Jogh Galt"};
        }

        public string [] GetPeopleArray()
        {
            return new string[3] { "John Dow", "Jane Dow", "Jogh Galt" };
        }

        public List<string> GetPeopleListNew()
        {
            return new List<string>() { "John Dow", "Jane Dow", "Jogh Galt" };
        }
    }
}
