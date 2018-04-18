using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>()
                {

                new Person() { Name = "John", PetName = "Dog", Age = 20},
                new Person() { Name = "Jane", PetName = "Cat", Age = 20},
                new Person() { Name = "Jeniffer", PetName = "Cat", Age = 20},
                new Person() { Name = "Frank", PetName = "Pig", Age = 20},
                new Person() { Name = "Bob", PetName = "Dog",Age = 20},
                new Person() { Name = "Alex", Age = 30},
                new Person() { Name = "JZ", Age = 30},
                new Person() { Name = "JZ", Age = 33}
                }
                ;
            var animals = new List<Pet>()
                {
                    new Pet() { Name = "Cat",Size=2},
                    new Pet() { Name = "Mouse",Size=1},
                    new Pet() { Name = "Dog",Size=3}
                }
                ;

            //var peopleWithPets =
            //    from p in people
            //    join a in animals on p.PetName equals a.Name
            //    //    into pa
            //    //from a in pa.DefaultIfEmpty()
            //    select new {p.Name,p.PetName,a.Size};

            var groupingResult  = people.GroupBy(p => new {p.PetName, p.Age});
            var keySelect = groupingResult.Select(k=>k.OrderBy(i=>i.Name.Length).FirstOrDefault()).ToList();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string PetName { get; set; }
        public int Age { get; set; }
    }

    class Pet
    {
        public string Name { get; set; }
        public int Size { get; set; }
    }
}
