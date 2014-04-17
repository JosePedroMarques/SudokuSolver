using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver;

namespace UnitTestProject1
{
    [TestClass]
    public class TestGrid
    {
        [TestMethod]
        public void TestGet()
        {
            Grid g = new Grid(9,0);
            g.Place(3,1,1);
            Assert.AreEqual(3,g.Get(1,1));
        }

        [TestMethod]
        public void TestCanPlace()
        {
            Grid g = new Grid(9,0);
            g.Place(3,1,1);
            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(false, g.CanPlace(3, i, 1)); //test row
                Assert.AreEqual(false, g.CanPlace(3, 1, i)); //test col
            }
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++ )
                    Assert.AreEqual(false, g.CanPlace(3, i, j)); //test row
            Assert.AreEqual(true, g.CanPlace(3, 5, 5)); //test col
        }

        [TestMethod]
        public void TestNumErrors()
        {
            Grid g = new Grid(9, 0);
            Assert.AreEqual(0, g.GetNumMistakes());
            g.Place(3,1,1);
            g.Place(3,0,1);
            Assert.AreEqual(2, g.GetNumMistakes());
            g.Place(0, 0, 1);
            Assert.AreEqual(0, g.GetNumMistakes());
        }
        [TestMethod]
        public void TestNumPlaced()
        {
            Grid g = new Grid(9, 0);
            Assert.AreEqual(0, g.GetNumPlaced());
            g.Place(3, 1, 1);
            g.Place(4, 0, 1);
            Assert.AreEqual(2, g.GetNumPlaced());
        }

        [TestMethod]
        public void TestGeneration()
        {
            Grid g = new Grid(9,10);
            Assert.AreEqual(0,g.GetNumMistakes());
            Assert.AreEqual(10,g.GetNumPlaced());
          
        }
    }
}
