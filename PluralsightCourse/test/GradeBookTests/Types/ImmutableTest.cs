using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GradeBookTests.Types
{
    [TestClass]
    public class ImmutableTest
    {
        [TestMethod]
        public void ImmutableValueType()
        {
            //21st Dec
            DateTime date = new DateTime(2017,12,21);
            date.AddDays(1);

            Assert.AreNotEqual(22,date.Day);

            date = date.AddDays(1);
            Assert.AreEqual(22, date.Day);
        }

        [TestMethod]
        public void ImmutableString()
        {
            //21st Dec
            string name = "alex";
            name.ToUpper();

            Assert.AreNotEqual("ALEX", name);

            name = name.ToUpper();
            Assert.AreEqual("ALEX", name);
        }
    }
}
