using System;
using People.Core;

namespace People.LayeredViewer
{
    class PeopleRepositoryFactory
    {
        public static IPeopleRepository GetPeopleRepositoryDynamically(string repositoryTypeFullName)
        {
            var type = Type.GetType(repositoryTypeFullName);

            if (type != null)
                return (IPeopleRepository)Activator.CreateInstance(type);

            return null;
        }
    }
}
