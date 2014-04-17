using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solver;

namespace UnitTestProject1
{
    [TestClass]
   public class TestRandomSolver
    {
        [TestMethod]
        public void TestRandomSolver1()
        {
            Grid g = new Grid(9,10);
            BacktrackingSolver rs = new BacktrackingSolver();
            Grid solution = rs.Solve(g);
            Assert.IsNotNull(solution);
            Assert.AreEqual(solution.GetNumMistakes(), 0);
            Assert.AreEqual(solution.GetNumPlaced(),81);
            Console.WriteLine(g);
        }

    }
}
