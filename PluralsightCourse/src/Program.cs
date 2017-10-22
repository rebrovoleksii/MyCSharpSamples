using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PluralSight.Grade
{
    public class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new ThrowAwayGradeBook();
            book.OnNameChanged += new NameChagedDelegate(OnNameChanges);
            book.OnNameChanged += new NameChagedDelegate(OnNameChanges);

            book.Name = "Alex's Gradebook";

            book.AddGrade(90);
            book.AddGrade(10.5f);

            using (StreamWriter file = File.CreateText("grades.txt"))
            {
                book.WriteGrades(file);
            }
            Console.WriteLine("Regular method called by variable type : {0}",book.GetClassName());
            Console.WriteLine("Virtual method called by instance type : {0}",book.GetClassNameVirtual());
            Console.ReadLine();
        }

        static void OnNameChanges(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("The name of the gradebook was changes from {0} to {1}", args.ExistingName, args.NewName);
        }
    }
}
