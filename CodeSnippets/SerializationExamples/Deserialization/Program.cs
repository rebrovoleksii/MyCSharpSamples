using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace DeserializationAndDynamicProperties
{
    class Program
    {
        static void test()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, @"C:\Users\Administrator\Desktop\DataHierarchyDefinition.xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            
            var paramsList = doc.GetElementsByTagName("UsagePatternParams");
            
            var NameValue = new Dictionary<string,string> { };

            for (int i = 0; i < paramsList.Count; i++)
			{
                NameValue.Add(paramsList.Item(i).SelectNodes("Name").Item(0).InnerText, paramsList.Item(i).SelectNodes("Value").Item(0).InnerText);
            }

            foreach (var item in NameValue)
            {
                Console.WriteLine("{0}:{1}",item.Key,item.Value);
            }

            var newStore = new MyBooks();

             foreach (var item in NameValue)
             {
                 var prop = newStore.GetType().GetProperty(item.Key);
                 if (prop != null) 
                {
                    //prop.SetValue(newStore,item.Value);
                }
             }
             Console.WriteLine("{0}:{1}", newStore.Payer, newStore.OrderTime);
            Console.ReadLine();
        }

        public class MyBooks
        {
            public string Payer { get; set; }
            public DateTime OrderTime { get; set; }

            [XmlAttribute]
            public int pages { get; set; }
        }
     
     
    }


}
