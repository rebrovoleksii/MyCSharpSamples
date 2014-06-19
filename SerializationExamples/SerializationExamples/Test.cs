using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace SerializationExamples
{
    class Test
    {
        static void Main()
        {

            var newobjFromFile = new Usages();

            string filePath = @".\Files\sample.xml";
            string fileForReplacement = @".\Files\cookies.xml";

            //Test.SerializeBooks(newLibrary, filePath);
            var extraTypes = new List<Type>();
            extraTypes.Add(typeof(Usage));
            extraTypes.Add(typeof(Param));
            newobjFromFile = Test.DeserializationHelper<Usages>(filePath, extraTypes);

            var usages = newobjFromFile.UsagesList;
                                             
            var xml = XDocument.Load(fileForReplacement);
                       
            foreach (var usage in usages)
            {
                foreach (var param in usage.Params)
                {
                    foreach (var forReplace in xml.Descendants().Where(x => x.Name==param.ParamValue))
                    {
                        Account newAccToReplaceValues = new Account();
                        switch (param.type)
                        {
                            case ParamType.Id: 
                                forReplace.Value = newAccToReplaceValues.AccountId.ToString();
                                break;
                            case ParamType.UserName:
                                forReplace.Value = newAccToReplaceValues.UserName;
                                break;
                            case ParamType.unique:
                                forReplace.Value = Guid.NewGuid().ToString();
                                break;
                        }
                     }
                }
                
            }
            xml.Save(fileForReplacement);
            Console.ReadLine();
        }

        #region Helpers
        public static T DeserializationHelper<T>(string FilePath,List<Type> includedTypes)
        {
            using (FileStream myFileStream = new FileStream(FilePath, FileMode.Open))
            {
                XmlSerializer myDeserializer = new XmlSerializer(typeof(T), includedTypes.ToArray());
                return (T)myDeserializer.Deserialize(myFileStream);
            }
        }
        
        public static void SerializeBooks(Usages books,string FilePath)
        {
            using (StreamWriter textWriter = new StreamWriter(FilePath))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(Usages));
                mySerializer.Serialize(textWriter, books);
            }
        }
        #endregion  
    }

    #region InnerClasses
    [Serializable()]
    [XmlRoot("Usages")]
    public class Usages
    { 
        [XmlElement("Usage")]
        public List<Usage> UsagesList {get; set;}
     }

    [Serializable()]
    public class Usage
    { 
        [XmlAttribute]
        public string Pattern {get; set;}

        [XmlAttribute]
        public string FirstUsageDate { get; set; }

        [XmlAttribute]
        public string LastUsageDate { get; set; }
        
        [XmlAttribute]
        public int Count { get; set; }

        [XmlAttribute]
        public int Increment { get; set; }

        [XmlArrayItem]
        public List<Param> Params { get; set; }
    }

    [Serializable()]
    public class Param
    {
        [XmlText]
        public string ParamValue { get; set; }

        [XmlAttribute]
        public ParamType type { get; set; }

    }

    public enum ParamType
    { 
        unique,
        UserName,
        Id,
        Date,

    }

#endregion
}
