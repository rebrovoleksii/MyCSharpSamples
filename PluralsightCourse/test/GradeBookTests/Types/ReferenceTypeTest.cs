using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PluralSight.Grade;

namespace Grades.Tests.Types
{
    [TestClass]
    public class ReferenceTypeTest
    {
        [TestMethod]
        public void SimpleReferenceTest()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Alex's grade book";

            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
