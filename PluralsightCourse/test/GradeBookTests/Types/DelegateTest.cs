using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PluralSight.Grade;

namespace GradeBookTests.Types.Delegate
{
    [TestClass]
    public class DelegateTest
    {
        const string DEFAULT_NAME = "John Doe's book";
        const string NEW_NAME = "Alex's Gradebook";
 
        [TestMethod]
        public void SimpleDelegateTest()
        {
            var book = new GradeBook(DEFAULT_NAME);
            book.OnNameChanged += new NameChagedDelegate(OnNameChangedHandler);

            book.Name = NEW_NAME;
        }

        [TestMethod]
        public void MultiCastDelegateTest()
        {
            var book = new GradeBook(DEFAULT_NAME);
            book.OnNameChanged += new NameChagedDelegate(OnNameChangedHandler);
            book.OnNameChanged += new NameChagedDelegate(OnNameChangednHandler2);

            book.Name = NEW_NAME;
        }

        private static void OnNameChangedHandler(object sender,NameChangedEventArgs args)
        {
            Console.WriteLine("OnNameChangedHandler fired");
            Assert.AreEqual(args.ExistingName, DEFAULT_NAME);
            Assert.AreEqual(args.NewName, NEW_NAME);
        }

        private static void OnNameChangednHandler2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("OnNameChangedHandler2 fired");

            Assert.IsInstanceOfType(sender, typeof(GradeBook));
            Assert.AreEqual(16, args.NewName.Length);
        }
    }
}
