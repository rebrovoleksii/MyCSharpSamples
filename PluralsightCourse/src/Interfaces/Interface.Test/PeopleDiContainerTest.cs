using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using People.Core;
using MyServiceContainer = People.DiContainer.Viewer.ServiceContainer;

namespace Interface.Test
{
    [TestClass]
    public class PeopleDiContainerTest
    {
        private Mock<IPeopleRepository> moqRepository;

        [TestInitialize]
        public void Setup()
        {
            moqRepository = new Mock<IPeopleRepository>();
            moqRepository.Setup(repository => repository.GetPeopleList()).Returns(new List<string> { "John Mock", "Jane Mock" });
            //MyServiceContainer.RegisterService<IPeopleRepository>(moqRepository.Object);
        }

        [TestMethod]
        public void TestWithMoq()
        {
            //arrange
            var mvm = new People.DiContainer.Viewer.MainViewModel();

            //act
            mvm.FetchData();

            //assert
            Assert.AreEqual(2, mvm.People.Count());
            Assert.IsTrue(mvm.People.Contains("John Mock"));
        }
    }
}
