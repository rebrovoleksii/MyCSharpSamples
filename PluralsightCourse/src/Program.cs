using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralSight.Grade
{
    public class Program
    {
        static void Main(string[] args)
        {
            var book = new GradeBook("Pluralsight book");
            book.OnNameChanged += new NameChagedDelegate(OnNameChanges);

            book.OnNameChanged += new NameChagedDelegate(OnNameChanges);

            book.Name = "Alex's Gradebook";
            Console.ReadLine();
        }

        static void OnNameChanges(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("The name of the gradebook was changes from {0} to {1}", args.ExistingName, args.NewName);
        }
    }
}
