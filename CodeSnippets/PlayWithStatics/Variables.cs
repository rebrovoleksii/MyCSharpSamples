using System;
using refl = System.Reflection;
using System.Text;

namespace PlayWithStatics
{
    class Variables
    {
         public static int classVariable;

            public int instanceVariable;

            public void printclassVariable(string instanceName)
            {
                Console.WriteLine("classVariable value for {0} : {1}", instanceName, classVariable);
            }

            static Variables()
            {
                classVariable = 100;
            }

            public Variables(int instvar)
            {
                this.instanceVariable = instvar;
            }
    }
}
