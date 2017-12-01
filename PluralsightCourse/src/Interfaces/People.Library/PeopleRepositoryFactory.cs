using System;
using System.Diagnostics.Eventing.Reader;
using People.Core;

namespace People.Library
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

        public static IPeopleRepository GetPeopleRepositoryDynamically(string repositoryTypeFullName)
        {
            var type = Type.GetType(repositoryTypeFullName);

            if (type != null)
                return (IPeopleRepository) Activator.CreateInstance(type);

            return null;
        }
    }
}
