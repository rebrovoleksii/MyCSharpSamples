using System;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PluralSight.Foods;
using PluralSight.Tests;

namespace PluralSight.Tests.Comparison
{
    [TestClass]
    public class ComparisonTest
    {
        [TestMethod]
        public void CustomComparerTest()
        {
            Food[] list = 
            {
                new Food("orange",FoodGroup.Fruit),
                new Food("banana",FoodGroup.Fruit),
                null,
                new Food("apple",FoodGroup.Fruit),
                new Food("pear",FoodGroup.Fruit)
            };

            Array.Sort(list, FoodNameComparer.Instance);
            Utils.WriteCollectionToTestsOutput(list);

            Assert.AreEqual("apple", list[1].Name);
        }

        [TestMethod]
        public void HashSetNaturalTypeEqualityTest()
        {
            var appleUpperCase = new FoodStruct("APPLE", FoodGroup.Fruit);

            var list = new HashSet<FoodStruct>
            {
                new FoodStruct("apple",FoodGroup.Fruit),
                new FoodStruct("banana",FoodGroup.Fruit),
                new FoodStruct("APPLE",FoodGroup.Fruit),
                new FoodStruct("pear",FoodGroup.Fruit)
            };

            Utils.WriteCollectionToTestsOutput(list);

            Assert.IsTrue(list.Contains(appleUpperCase));
        }

        [TestMethod]
        public void HashSetPluggedInEqualityTest()
        {
            var appleUpperCase = new FoodStruct("APPLE", FoodGroup.Fruit);

            var list = new HashSet<FoodStruct>(FoodStructEqualityComparer.Instance);
            list.Add(new FoodStruct("apple", FoodGroup.Fruit));
            list.Add(new FoodStruct("banana", FoodGroup.Fruit));
            list.Add(new FoodStruct("APPLE", FoodGroup.Fruit));
            list.Add(new FoodStruct("pear", FoodGroup.Fruit));

            Utils.WriteCollectionToTestsOutput(list);

            Assert.AreEqual(3, list.Count);

            // default comparer make use of default equality implementation
            var listDefaultComparer = new HashSet<FoodStruct>(list, EqualityComparer<FoodStruct>.Default);
            listDefaultComparer.Add(appleUpperCase);

            Utils.WriteCollectionToTestsOutput(list);

            Assert.AreEqual(4, listDefaultComparer.Count);
        }

        [TestMethod]
        public void StringComparerTest()
        {
            var caseSensitiveList = new HashSet<string>();
            caseSensitiveList.Add("apple");
            caseSensitiveList.Add("banana");
            caseSensitiveList.Add("APPLE");
            caseSensitiveList.Add("pear");

            Utils.WriteCollectionToTestsOutput(caseSensitiveList, "Case sensitive hash set:");

            var ingnoreCaseSet = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
            ingnoreCaseSet.Add("apple");
            ingnoreCaseSet.Add("banana");
            ingnoreCaseSet.Add("APPLE");
            ingnoreCaseSet.Add("pear");

            Utils.WriteCollectionToTestsOutput(ingnoreCaseSet, "Case insensitive hash set using StringComparer:");

            var res = String.Compare("50.1", "50,1", CultureInfo.GetCultureInfo("de-DE"), CompareOptions.IgnoreSymbols);

            var res1 = String.Compare("50.1", "50,1", false, CultureInfo.InvariantCulture);
            Assert.AreNotEqual(res, res1);
        }
    }
}
