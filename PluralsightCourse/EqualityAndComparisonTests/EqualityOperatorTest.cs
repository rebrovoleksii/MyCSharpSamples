using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PluralSight.Tests.EqualityOperator
{
    [TestClass]
    public class EqualityOperatorTest
    {
        [TestMethod]
        public void EqualityOperatorValueTypeTest()
        {
            int x = 3;
            int y = 3;

            // this is impementation of IEquatable since x.Equals(int) is better type match
            // them object.Equals(obj)
            Assert.IsTrue(x.Equals(y));

            // under the hood in IL the low lever langiage operator is used to compare values
            Assert.IsTrue(x == y);
        }

        [TestMethod]
        public void EqualityOperatorStringTest()
        {
            string me = "Alex";
            string meagain = string.Copy(me);

            Assert.IsFalse(ReferenceEquals(me, meagain));

            // this is impementation of IEquatable since x.Equals(string) is better type match
            // them object.Equals(obj)
            Assert.IsTrue(me.Equals(meagain));

            // under the hood the overloaded == operator is used
            // public static bool operator ==(string a, string b)
            Assert.IsTrue(me == meagain);
        }

        [TestMethod]
        public void EqualityOperatorReferenceTypeTest()
        {
            var x = new Book();
            var y = x;

            // this is impementation of IEquatable since x.Equals(int) is better type match
            // them object.Equals(obj)
            Assert.IsTrue(x.Equals(y));

            // under the hood in IL the low lever langiage operator is used to addresses in memory
            // since address is also value - reference comparison works fine
            Assert.IsTrue(x == y);
        }

        class Book { }
    }
}
