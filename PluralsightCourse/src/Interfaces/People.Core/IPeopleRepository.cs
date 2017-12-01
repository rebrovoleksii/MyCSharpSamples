using System.Collections.Generic;

namespace People.Core
{
    public interface IPeopleRepository
    {
        IEnumerable<string> GetPeopleList();
    }
}
