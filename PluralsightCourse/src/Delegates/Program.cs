using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = InvokeDelegate(3, (x) =>
            {
                Console.WriteLine(x);
                return $"Delegated called {x}";
            });
        }

        private static object InvokeDelegate<T>(T parameter, Func<T, object> someDelegate)
        {
            return someDelegate(parameter);
        }
    }
}
