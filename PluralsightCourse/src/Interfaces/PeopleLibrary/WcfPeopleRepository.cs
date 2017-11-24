using System.Collections.Generic;

namespace PeopleLibrary
{
    public class WcfPeopleRepository : IPeopleRepository
    {
        public IEnumerable<string> GetPeopleList()
        {
            var proxy = new People.WcfService.PeopleServiceClient("PeopleServiceEndPoint");
            return proxy.GetPeople();
        }
    }
}