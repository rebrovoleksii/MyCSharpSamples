using System;
using System.Collections;
//using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PluralSight.CustomCollections;

namespace PluralSight.Tests.Collections
{
    [TestClass]
    public class ListTest
    {
        private List<string> listOfHetmans;
        [TestInitialize]
        public void MyTestMethod()
        {
            listOfHetmans = new List<string>() {
                "Petro Sagaidacniy",
                "Bogdan Khmelnickiy",
                "Petro Doroshenko",
                "Ivan Mazepa",
                "Pylup Orlyk",
                "Kyrylo Rozumowskiy",
                "Pavlo Skoropadskiy"
            };
        }


        [TestMethod]
        public void DefaultListCapacityEquals8Test()
        {
            Assert.AreEqual(7, listOfHetmans.Count);
            //by default List Capacity is 8
            Assert.AreEqual(8, listOfHetmans.Capacity);
        }

        [TestMethod]
        public void CustomListCapacityFromConstructorTest()
        {
            var listOfHetmansCustomCapacity = new List<string>(10);
            listOfHetmansCustomCapacity.AddRange(listOfHetmans);

            Assert.AreEqual(7, listOfHetmansCustomCapacity.Count);
            //by default List Capacity is 8
            Assert.AreEqual(10, listOfHetmansCustomCapacity.Capacity);
        }

        [TestMethod]
        public void ListCapacityDoubledWhenAddnigElementsTest()
        {
            listOfHetmans.Add("Pavlo Polubotok");
            listOfHetmans.Add("Dmytro Vishneveckiy");

            Assert.AreEqual(9, listOfHetmans.Count);
            //default List Capacity is doubled from 8 to 16
            Assert.AreEqual(16, listOfHetmans.Capacity);
        }

        [TestMethod]
        [Description(@"ReadOnlyCollection is a wrapper around List. Underlying collection
            might be changed and this affects wrapper e.g. so it's more like indication of your purpose")]
        [ExpectedException(typeof(NotSupportedException))]
        public void List_AsReadOnlyMethod_Test()
        {
            // if you think that method might corrupt data in list
            // you can create it's read only copy 
            IList<string> immutableHetmans = listOfHetmans.AsReadOnly();
            //same as
            //var immutable = new ReadOnlyCollection<string>(listOfHetmans);

            string person = "Roman Shuhevic";
            listOfHetmans.Add(person);
            // Utils.WriteCollectionToTestsOutput(immutableHetmans);
            // this shows that both collection reference same memory object 
            Assert.IsTrue(immutableHetmans.Contains(person));

            Action<IList<string>> addCommaFunc = list =>
            {
                list[1] = list[1] + ",";
            }; 

            addCommaFunc(immutableHetmans);
        }

        [TestMethod]
        [Description("Collection class provides mechanism via protected methods to override List behavior if needed")]
        [ExpectedException(typeof(ArgumentException))]
        public void Collection_AllowsOverrideListAddBehavior_Test()
        {
            var customHetmans = new NonBlankStringList(listOfHetmans);
            customHetmans.Add("Baida Vyshneveckiy");
            customHetmans.Add("");
        }

        [TestMethod]
        [Description("Collection class provides mechanism via protected methods to override List behavior if needed")]
        [ExpectedException(typeof(ArgumentException))]
        public void Collection_AllowsOverrideListSetBehavior_Test()
        {
            var customHetmans = new NonBlankStringList(listOfHetmans);
            customHetmans[1] = "Baida Vyshneveckiy";
            customHetmans[2] = null;
        }

        [TestMethod]
        public void Test()
        {
            IEnumerable<int> enumerable = new List<int>();
            ICollection<int> collection = new IntList();
            IList<int> list = new IntList();
        }

        class IntList : IList<int>
        {
            public IEnumerator<int> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Add(int item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(int item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(int[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public bool Remove(int item)
            {
                throw new NotImplementedException();
            }

            public int Count { get; }
            public bool IsReadOnly { get; }
            public int IndexOf(int item)
            {
                throw new NotImplementedException();
            }

            public void Insert(int index, int item)
            {
                throw new NotImplementedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotImplementedException();
            }

            public int this[int index]
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }
        }
    }
}
