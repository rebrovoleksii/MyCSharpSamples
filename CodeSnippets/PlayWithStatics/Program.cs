using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayWithStatics
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Variables
            Variables sample1 = new Variables(1);
            Variables sample2 = new Variables(2);

            Console.WriteLine("instanceVariable value for sample1: {0}", sample1.instanceVariable);
            Console.WriteLine("instanceVariable value for sample2: {0}", sample2.instanceVariable);
            sample1.printclassVariable("sample1");
            sample2.printclassVariable("sample2");

            Variables.classVariable = 200;

            sample1.printclassVariable("sample1");
            sample2.printclassVariable("sample2");

            Console.ReadKey();
            #endregion Variables
        }
    }
}
