using System.Collections.Generic;

namespace ExplicitImplementation
{
    interface IPersistable
    {
        string Save();
        void Load();
    }
}
