using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class TestEvolutionarySolver
    {
        [TestMethod]
        public void TestInitialPopulation()
        {
            Grid g = new Grid(9,8);
            EvolutionarySolver es = new EvolutionarySolver();
            var initPop = es.GetInitialPopulation(g);
            foreach (var grid in initPop)
            {
                  Assert.IsTrue(grid.GetNumPlaced() >= g.GetNumPlaced());
                var empty = grid.GetEmptyPositions();
                  var isect = g.GetEmptyPositions().Intersect(empty).ToList();
                
                foreach (var i in isect)
                {
                    Assert.IsTrue(empty.Contains(i));
                }
                 
            }
         

        }
        [TestMethod]
        public void TestFitness()
        {
            Grid g = new Grid(9,10);
            EvolutionarySolver es = new EvolutionarySolver();   
            Assert.AreEqual(71,es.GetFitness(g));
            g.Place(8,g.GetEmptyPositions().First());
            Assert.AreEqual(70, es.GetFitness(g));
            g.Place(8, g.GetEmptyPositions().First());
            Assert.AreEqual(2069, es.GetFitness(g));

        }
    }
}
    