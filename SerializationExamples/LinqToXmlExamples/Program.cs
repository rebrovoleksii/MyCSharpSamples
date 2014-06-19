using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LinqToXmlExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string meteringPatternFilePath = @"C:\Users\Administrator\Desktop\cookies.xml";

            var loadedXmlMeteringPattern = XDocument.Load(meteringPatternFilePath);

            var sessionsFromFile =
                 loadedXmlMeteringPattern.Root.Elements("session");

            Program.GetInputsForMetering(sessionsFromFile);

          
        }

        private static void GetInputsForMetering(IEnumerable<XElement> sessions)
        {
            foreach (var session in sessions)
            {

                var serviceName = session.Element("ServiceName").Value;
                var inputsList = session.Elements("inputs");
                var inputParameters = inputsList.Elements();

              
                Console.WriteLine(serviceName);
                foreach (var item in inputParameters)
                {
                    Console.WriteLine("{0}:{1}", item.Name, item.Value);
                }

                Console.WriteLine(session.Elements("session").Count());
                Console.ReadLine();

                if (session.Elements("session").Count() != 0 )
                {
                    GetInputsForMetering(session.Elements("session"));
                }
                else { 
                    Console.WriteLine("No nested sessions");
                    Console.ReadLine();
                }


            }
            }
        }
    }

