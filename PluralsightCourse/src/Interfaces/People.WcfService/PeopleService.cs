using System.Collections.Generic;

namespace People.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class PeopleService : IPeopleService
    {
        public IEnumerable<string> GetPeople()
        {
            return new[] { "John Wcf", "Jane Wcf", "Galt Wcf" };
        }
    }
}
