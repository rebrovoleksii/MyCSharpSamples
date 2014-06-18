using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace SerializationExamples
{
    class Test
    {
        static void Main()
        { 
        var newLibrary = new MyBooks();
        newLibrary.Author = "J.J. Martin";
        newLibrary.Book = "Game of Thrones";
        newLibrary.pages = 100;

        var newLibraryFromFile = new MyBooks();

        string filePath = Path.Combine(Environment.CurrentDirectory,"NewBooks.xml");

        Test.SerializeBooks(newLibrary, filePath);
        //newLibraryFromFile = Test.DeserializeBooks(filePath);

        //Console.WriteLine("Author : {0}, Book : {1}", newLibraryFromFile.Author, newLibraryFromFile.Book);
        Console.ReadLine();
        }

        public static MyBooks DeserializeBooks(string FilePath)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(MyBooks));
            FileStream myFileStream = new FileStream(FilePath,FileMode.Open);
            return (MyBooks)mySerializer.Deserialize(myFileStream);
        }
        
        public static void SerializeBooks(MyBooks books,string FilePath)
        {
            using (StreamWriter textWriter = new StreamWriter(FilePath))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(MyBooks));
                mySerializer.Serialize(textWriter, books);
            }
        }
    }

    public class MyBooks
    {
        public string Book { get; set; }
        public string Author {get; set; }

        [XmlAttribute]
        public int pages { get; set; }
    }
}
