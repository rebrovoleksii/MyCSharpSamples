using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PluralSight.GradeBookConsole;

namespace GradeBookTests
{
    [TestClass]
    public class GradeBookConsoleTest
    {
        [TestMethod]
        public void CalculateLowestGrade()
        {
            var gradeBook = new GradeBook();
            gradeBook.AddGrade(10);
            gradeBook.AddGrade(90);

            var stat = gradeBook.CalculateStatitics();

            Assert.AreEqual(10, stat.LowestGrade);
        }

        [TestMethod]
        public void CalculateHighestGrade()
        {
            var gradeBook = new GradeBook();
            gradeBook.AddGrade(10);
            gradeBook.AddGrade(90);

            var stat = gradeBook.CalculateStatitics();

            Assert.AreEqual(90, stat.HighestGrade);
        }

        [TestMethod]
        public void CalculateAverageGrade()
        {
            var gradeBook = new GradeBook();
            gradeBook.AddGrade(10);
            gradeBook.AddGrade(90);
            gradeBook.AddGrade(6);

            var stat = gradeBook.CalculateStatitics();

            Assert.AreEqual(35.33, stat.AverageGrade,0.01);
        }
    }
}
