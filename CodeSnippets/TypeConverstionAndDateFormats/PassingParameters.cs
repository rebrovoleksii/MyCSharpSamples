using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Misc
{
    public class PassingParameters
    {
        private class Container
        {
            internal byte containerByte = 1;
        }

        private int valueTypeVariable = 1;
        private Container refTypeVariable = new Container();
        private string stringVariable = "hello";

        private void PassValueTypeParameter(int x)
        {
             x += 100;
        }
        private void PassValueTypeParameterByReference(ref int x)
        {
             x += 100;
        }
        private void PassReferenceTypeParameter(Container x)
        {
            //now value type var could be updated
            x.containerByte += 8;
            //but reference to passed object will not
            x = null;
        }
        private void PassReferenceTypeParameterByReference(ref Container x)
        {
            //now reference could be changes
            x = null;
        }

        public static void Test()
        {
            var testObject = new PassingParameters();
            Console.WriteLine("Value type example initial:{0}", testObject.valueTypeVariable);
            testObject.PassValueTypeParameter(testObject.valueTypeVariable);
            Console.WriteLine("Value type example after passing by value:{0}", testObject.valueTypeVariable);
            testObject.PassValueTypeParameterByReference(ref testObject.valueTypeVariable);
            Console.WriteLine("Value type example after passing by reference:{0}", testObject.valueTypeVariable);
            Console.WriteLine("===============================================================================");
            Console.WriteLine("Value of object variable initial:{0}", testObject.refTypeVariable.containerByte);
            testObject.PassReferenceTypeParameter(testObject.refTypeVariable);
            Console.WriteLine("Value of object variable after passing:{0}", testObject.refTypeVariable.containerByte);
            Console.WriteLine("Value of object refernce WAS NOT changed:{0}", testObject.refTypeVariable == null);
            Console.WriteLine("===============================================================================");
            testObject.PassReferenceTypeParameterByReference(ref testObject.refTypeVariable);
            Console.WriteLine("Value of object refernce WAS changed:{0}", testObject.refTypeVariable == null);
            Console.ReadLine();
        }
    }
}
