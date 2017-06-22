using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PluralSight.Grade;

namespace Grades.Tests.Types
{
    [TestClass]
    public class ReferenceTypeTest
    {
        [TestMethod]
        public void StringComparisonTest()
        {
            string name1 = "Alex";
            string name2 = "alex";

            //enum
            bool result = String.Equals(name1,name2,StringComparison.InvariantCultureIgnoreCase);
            /*
             * enum could not be replaced by associated int value 
             * bool resultFalse = String.Equals(name1, name2, 3);  
             */  
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVarsHoldValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;

            Assert.AreNotEqual(x1, x2);            
        }

        [TestMethod]
        public void GradeBook_ChangeInstanceVariable_ReferencesToSameObject_Test()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Alex's grade book";

            Assert.AreEqual(g1.Name, g2.Name);
        }

        [TestMethod]
        public void GradeBook_ChangeInstanceVariable_ReferencesDifferentObjects_Test()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook();
            g1.Name = "Alex's grade book";

            Assert.IsNull(g2.Name);
            Assert.AreEqual("Alex's grade book", g1.Name);
        }

        [TestMethod]
        public void Array_ReferenceType_Test()
        {
            const int size = 3;
            float[] grades = new float[size];
            
            float grade = 81.9f;
            int position = 1;
            AddGrade(grades, grade, position);

            Assert.AreEqual(81.9f, grades[1]);            
        }

        private void AddGrade(float[] array,float grade, int position)
        {
            // this would fail test
            // array = new float[2];
            array[position] = grade;
        }

        #region Passing parameters

        [TestMethod]
        public void RefrerenceTypePassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            const string name = "Test";
            UpdateGradeBookName(book1, name);

            Assert.AreEqual(name, book2.Name);            
        }

        private void UpdateGradeBookName(GradeBook book,string name)
        {
            book.Name = name;
        }

        [TestMethod]
        public void RefrerenceTypePassByValue_UpdateReference()
        {
            GradeBook book1 = new GradeBook();
            UpdateGradeBookReferenceAndName(book1, "New");

            //reference to object is not updated
            // that's why Name is not assigned
            Assert.IsNull(book1.Name);
        }

        [TestMethod]
        public void RefrerenceTypePassByReference()
        {
            // book1 should be assgined to be sued with ref
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;
            UpdateGradeBookReferenceAndName(ref book1, "New");

            Assert.AreEqual("New",book1.Name);
            // this reference wasn't changed
            Assert.IsNull(book2.Name);
        }

        private void UpdateGradeBookReferenceAndName(GradeBook book, string name)
        {
            //original object reference isn't changed
            book = new GradeBook();
            book.Name = name; 
        }

        private void UpdateGradeBookReferenceAndName(ref GradeBook book, string name)
        {
            //original object reference updated
            book = new GradeBook();
            book.Name = name;
        }

        [TestMethod]
        public void ValueTypePassByValue()
        {
            int x = 77;
            IncrementNumber(x);
            Assert.AreEqual(77, x);
        }

        [TestMethod]
        public void ValueTypePassByReference()
        {
            //x should be intialized following gives warning
            //int x;
            int x = 77;
            IncrementNumber(ref x);
            Assert.AreEqual(78, x);
        }

        private void IncrementNumber(int number) 
        {
            //value is copied so original variale not affected
            number += 1;
        }

        private void IncrementNumber(ref int number)
        {
            //value is copied so original variale not affected
            number += 1;
        }
        #endregion  
    }
}
