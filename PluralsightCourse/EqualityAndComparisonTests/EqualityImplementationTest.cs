using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PluralSight.Foods;
using FoodGroup = PluralSight.Foods.FoodGroup;

namespace PluralSight.Tests.Equality
{
    [TestClass]
    public class EqualityImplementationTest
    {
        private Food apple;
        private CookedFood stewedApple;
        private CookedFood bakedApple;
        private Food apple1;

        [TestMethod]
        public void ValueTypeTest()
        {
            FoodStruct apple = new FoodStruct("apple", FoodGroup.Fruit);
            FoodStruct apple1 = new FoodStruct("apple", FoodGroup.Fruit);

            FoodStruct otherApple = new FoodStruct("red apple", FoodGroup.Fruit);

            FoodStruct steak = new FoodStruct("red apple", FoodGroup.Meat);

            Assert.IsFalse(ReferenceEquals(apple, apple1));

            //Test object.Equals implemented corretly
            Assert.IsTrue(apple.Equals((object)apple1));
            Assert.IsFalse(apple.Equals((object)steak));
            Assert.IsTrue(object.Equals(apple, apple1));
            Assert.IsFalse(apple.Equals(null), "object equals doesn't check for null");
            Assert.IsFalse(apple.Equals(new int[1]), "object equals doesn't check types");

            // By default non primitive value types doesn't have == overloaded
            Assert.IsTrue(apple == apple1);
            Assert.IsTrue(otherApple != steak);

            Assert.IsTrue(apple.Equals(apple1));
            Assert.IsFalse(apple.Equals(otherApple));
            Assert.IsFalse(apple.Equals(steak));
        }

        [TestInitialize]
        public void Setup()
        {
            apple = new Food("apple", FoodGroup.Fruit);
            stewedApple = new CookedFood("apple", FoodGroup.Fruit, "stewed");
            bakedApple = new CookedFood("apple", FoodGroup.Fruit, "baked");
            apple1 = new Food("apple", FoodGroup.Fruit);
        }

        [TestMethod]
        public void ReferenceTypeTest()
        {
            Assert.IsFalse(ReferenceEquals(apple, apple1));
            Assert.IsTrue(apple.Equals(apple1));
        }

        [TestMethod]
        public void ReferenceTypeEqualityOperatorTest()
        {
            Assert.IsFalse((apple == null));
            Assert.IsTrue((null != apple));
        }

        [TestMethod]
        public void ReferenceTypeTest1()
        {
            Assert.IsFalse(apple.Equals(stewedApple), "Apple equals stewed apple");
        }
        [TestMethod]
        public void ReferenceTypeTest2()
        {
            Assert.IsFalse(apple.Equals(bakedApple), "Apple equals stewed apple");
        }
        [TestMethod]
        public void ReferenceTypeTest3()
        {
            Assert.IsFalse(bakedApple.Equals(stewedApple), "Apple equals stewed apple");
            Assert.IsFalse(bakedApple == stewedApple);
        }

        [TestMethod]
        public void ReferenceTypeTest4()
        {
            Food newBakedApple = new CookedFood("apple",FoodGroup.Fruit,"baked");
            Food newStewedApple = new CookedFood("apple", FoodGroup.Fruit, "stewed");

            // this works since inside == called static object.Equals(newBakedApple,newStewedApple)  
            // which in turn calls in runtime virtual object.Equals implementations for CookedFood
            Assert.IsFalse(bakedApple == stewedApple);
        }
    }
}
