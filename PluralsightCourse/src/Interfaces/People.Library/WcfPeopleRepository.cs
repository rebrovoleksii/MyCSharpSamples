using System.Collections.Generic;
using People.Core;
using People.Library.WcfServiceClient;

namespace People.Library
{
    public class WcfPeopleRepository : IPeopleRepository
    {
        public IEnumerable<string> GetPeopleList()
        {
            var proxy = new PeopleServiceClient("PeopleServiceEndPoint");
            return proxy.GetPeople();
        }
    }
}