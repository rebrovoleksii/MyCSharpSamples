using System;
using System.Collections;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using People.CSVRepository;
using People.LayeredViewer;

namespace Interface.Test
{
    [TestClass]
    public class PeopleLayerViewerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            var viewModel = new MainViewModel();

            //act
            viewModel.FetchData();

            //assert
            Assert.IsNotNull(viewModel.People);
            Assert.AreEqual(3, viewModel.People.Count());
        }
    }
}
