using System;
using System.Collections;
using System.Diagnostics;

namespace PluralSight.Tests
{
    public static class Utils
    {
        static Utils()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        }
        
        public static void WriteCollectionToTestsOutput(IEnumerable list, string description = "Result:")
        {
            Trace.WriteLine(description);
            foreach (var item in list)
            {
                Trace.WriteLine(item);
            }
        }

        public static void WriteTypeToOutPut<T>(T obj)
        {
            Trace.WriteLine("Type of variable : " + obj.GetType()); 
        }


        public static void WriteVariableToOutPut<T>(T obj)
        {
            Trace.WriteLine("value of variable : " + obj.ToString());
        }
    }
}
