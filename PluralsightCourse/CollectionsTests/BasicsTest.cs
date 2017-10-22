using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PluralSight.Foods;
using PluralSight.Tests;

namespace PluralSight.Tests.Collections
{
    [TestClass]
    public class BasicsTest
    {
        private string[] daysOfWeek;

        [TestInitialize]
        public void MyTestMethod()
        {
            daysOfWeek = new string[7] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        }

        [TestMethod]
        public void ForeachReadOnlyTest()
        {
            foreach (var day in daysOfWeek)
            {
                //you can't assign new value to var in foreach
                //day = day + "'s";                              
            }
        }

        [TestMethod]
        public void Foreach_CanModifyReferenceTypeValue_Test()
        {
            Food[] myLunch = new Food[2] { 
                new Food("Jogurt",FoodGroup.Dairy),
                new Food("Banana",FoodGroup.Fruit)
            };
            foreach (var meal in myLunch)
            {
                // we have reference in meal so we can't change it (literally replace address in memory)
                // meal = new Food("My " + meal.Name,meal.Type);
                // but you can change object property
                meal.Name = "My " + meal.Name;
            }
            Utils.WriteCollectionToTestsOutput(myLunch);
        }

        [TestMethod]
        public void CollectionEqualityOperator_ComparesByReference_Test()
        {
            int[] x1 = { 1, 4, 9, 16 };
            var x2 = x1;

            int[] x3 = { 1, 4, 9, 16 };

            Assert.IsTrue(x1 == x2);
            Assert.IsFalse(x1 == x3);
        }

        [TestMethod]
        [Description(@"
        - Array typyzation implemented using CLR while other collections use generics
        - Other collections implemented based on Array
        - Array has fast index based since it's just memory offset from the beginning of array
        - But that's why array has fixed size (you can put something beyound array limit in memory since it might be occupied already)
        ")]
        public void ArrayTest()
        {
            
        }

        [TestMethod]
        [Description("Array covariance is broken, covariance IEnumerable is ok, for other Collections it's not supported")]
        [ExpectedException(typeof(ArrayTypeMismatchException))]
        public void ArrayCovarianceTest()
        {
            Utils.WriteTypeToOutPut<Array>(daysOfWeek);

            object[] objArr = new object[3];
            Utils.WriteTypeToOutPut<Array>(objArr);

            // example of Array covariance - .net allows to cast array of Derived type (Dereived[]) to array of Base type (Base[])
            //type of reference still System.Object[]
            //type of object stored is still  System.String[]
            objArr = daysOfWeek;
            Utils.WriteCollectionToTestsOutput(objArr);
            // runtime exception : System.String[] can't store int
            objArr[1] = 1;

            // not possible - compile exception
            //daysOfWeek[1] = 1;

            // not possible - compile exception, List isn't covariant
            //List<object> lisst = new List<string> {"test"};
        }

        [TestMethod]
        public void ICollection_IsIEnumerableWithEditingAndCount_Test()
        {
            ICollection<string> collectionOfDays = new List<string>(daysOfWeek);
            // ICollection it's enumerable that allows modification + Count
            // but without index access,following not possible
            //collectionOfDays[1]="Slave day";
            collectionOfDays.Add("Slave day");
            Assert.AreEqual(8, collectionOfDays.Count);
        }

        [TestMethod]
        public void IList_IsICollectionWithIdndexBasedAccess_Test()
        {
            IList<string> collectionOfDays = new List<string>(daysOfWeek);
            // IList it's ICollection that allows index access 
            // and consequently index related related operations
            collectionOfDays.Insert(1,"Slave day");
            Assert.AreEqual("Slave day", collectionOfDays[1]);
        }

        [TestMethod]
        public void ICollection_IsReadOnlyProperty_CheckIfUnderLyingCollectionCanBeModified_Test()
        {
            // that's possible since Array implements ICollection<T>
            ICollection<string> collection = (ICollection<string>)daysOfWeek;
            
            // we know that Array doesn't support adding element so we need
            // to check if underlying collection is actually could be modified
            if (!collection.IsReadOnly)
            {
                collection.Add("Slave day");
            }

            Assert.IsFalse(collection.Contains("Slave day"));
        }


    }
}
