using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PluralSight.Grade;

namespace PluralSight.Tests.Equality
{
    [TestClass]
    public class EqualityTest
    {

        [TestMethod]
        public void StringComparisonTest()
        {
            string name1 = "Alex";
            string name2 = "alex";

            //enum
            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            /*
             * enum could not be replaced by associated int value 
             * bool resultFalse = String.Equals(name1, name2, 3);  
             */
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StringComparedByValueTest()
        {
            string name1 = "Alex";
            string name2 = String.Copy(name1);
                
            // in .NET object.Equals(object obj) is overriden for strings to compare vaulue
            var result = name1.Equals((object)name2);
            Assert.IsTrue(result);

            result = object.ReferenceEquals(name1,name2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TupleComparedByValueTest()
        {
            Tuple<int, int> tuple1 = Tuple.Create<int, int>(1, 2);
            Tuple<int, int> tuple2 = Tuple.Create<int, int>(1, 2);
           
            // in .NET object.Equals(object obj) is overriden for tuples to compare value
            var result = tuple1.Equals((object)tuple2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StructComparedByValueTest()
        {
            Hryvna salary = new Hryvna { Amount = 100 };
            Hryvna bonus = new Hryvna { Amount = 100 };

            // in .NET object.Equals(object obj) is overriden for struct to compare 
            // each field value but it uses reflection hence it slow
            // recommended to override Equals
            var result = salary.Equals((object)bonus);
            Assert.IsTrue(result);

            Assert.IsFalse(ReferenceEquals(salary, bonus));
        }
        struct Hryvna
        {
            public int Amount { get; set; }
            const string sign = "UAH";
        }

        [TestMethod]
        public void ReferenceTypesComparedByReferenceTest()
        {
            GradeBook book1 = new GradeBook("Alex's book");
            GradeBook book2 = new GradeBook("Alex's book");

            var result = book1.Equals(book2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ObjectEqualsNullReferenceExceptionTest()
        {
            GradeBook book1 = new GradeBook("Alex's book");
            GradeBook book2 = null;
            
            var result = book2.Equals(book1);
        }

        [TestMethod]
        public void StaticEqualsCompareWithNullTest()
        {
            GradeBook book1 = new GradeBook("Alex's book");
           
            // static object.Equals can't be overriden
            // inside it make call to virtual object.Equals
            // so if virtual Equals overriden
            // static Equals will work same way
            var result1 = object.Equals(book1, null);
            var result2 = object.Equals(null, book1);

            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(null == null);
        }
    }
}
