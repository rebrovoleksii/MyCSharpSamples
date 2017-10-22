using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSight.Grade;

namespace GradeBookTests.OOP
{
    [TestClass]
    public class VirtualMethodTest
    {
        [TestMethod]
        public void VirtualMethod_Test()
        {
            GradeBook book = new ThrowAwayGradeBook();

            //by default method of variable type is called in this case  GradeBook.GetClassName()
            var typeOfVariable = book.GetClassName();

            //if method is virtual in runtime method of type that instance is actually stored is called
            //in this case ThrowAwayGradeBook.GetClassNameVirtual()
            var typeOfInstance = book.GetClassNameVirtual();

            Assert.AreEqual("GradeBook", typeOfVariable);
            Assert.AreEqual("ThrowAwayGradeBook", typeOfInstance);

        }

        [TestMethod]
        public void PolymorphicMethod_Test()
        {
            GradeBook book = new ThrowAwayGradeBook();
            AddGrades(book);
            var stat = book.CalculateStatitics();

            Assert.AreEqual(95, stat.AverageGrade);

            book = new GradeBook();
            AddGrades(book);
            stat = book.CalculateStatitics();

            Assert.AreEqual(90, stat.AverageGrade);
        }

        private void AddGrades(GradeBook book)
        {
            book.AddGrade(90);
            book.AddGrade(100);
            book.AddGrade(80);
        }
    }
}
