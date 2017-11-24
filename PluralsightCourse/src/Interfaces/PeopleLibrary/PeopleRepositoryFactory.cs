using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLibrary
{
    public static class PeopleRepositoryFactory
    {
        public static IPeopleRepository GetPeopleRepository(RepositoryType repoType)
        {
            switch (repoType)
            {
                case RepositoryType.SimpleRepo:
                    return new SimplePeopleRepository();
                case RepositoryType.WcfRepo:
                    return new WcfPeopleRepository();
                default:
                    return null;
            }    
        }
    }
}
