using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardStorage standardStorage = new StandardStorage();
            ISavable savable = new StandardStorage();
            IPersistable persistable = new StandardStorage();

            Console.WriteLine("Standard implementation");
            Console.WriteLine("===========================================");
            Console.WriteLine("Concrete Class: {0}", standardStorage.Save());
            Console.WriteLine("ISavable: {0}", savable.Save());
            Console.WriteLine("IPersistable: {0}", persistable.Save());
            Console.WriteLine("(IPersistable)standardStorage: {0}", ((IPersistable)standardStorage).Save());
            Console.WriteLine("===========================================");
            Console.WriteLine();

            //not possible - ISavable doesn't know anything about IPersistable.Load()
            //savable.Load();



            ExplicitStorage explicitStorage = new ExplicitStorage();
            savable = new ExplicitStorage();
            persistable = new ExplicitStorage();

            Console.WriteLine("Explicit implementation");
            Console.WriteLine("===========================================");
            Console.WriteLine("Concrete Class: {0}", explicitStorage.Save());
            Console.WriteLine("ISavable: {0}", savable.Save());
            Console.WriteLine("IPersistable: {0}", persistable.Save());
            Console.WriteLine("(IPersistable)standardStorage: {0}", ((IPersistable)explicitStorage).Save());
            Console.WriteLine("===========================================");

            Console.ReadLine();
        }
    }

    public class StandardStorage : ISavable, IPersistable, IVoidSaveable
    {
        public void Load()
        {
            Console.WriteLine(": IPersistable Load  method called");
        }

        public string Save()
        {
            return "Standard Save";
        }


        // method overload by return type isn't possible in C#
        // so we can implement one of the interfaces explicitly and have 2 methods with diff return type/same names
        void IVoidSaveable.Save()
        {
            throw new NotImplementedException();
        }
    }

    public class ExplicitStorage : ISavable, IPersistable
    {
        public void Load()
        {
            throw new NotImplementedException();
        }

        // if comment this method out - new ExplicitStorage().Save() won't compile
        // since we have only explicit implemenattions
        // that could be called on interface variables only
        public string Save()
        {
            return "Standard Save.";
        }

        //explicit implementation doesn't contain access modificator
        string ISavable.Save()
        {
            return "ISavable called.";
        }

        string IPersistable.Save()
        {
            return "IPersistable called.";
        }
    }
}
