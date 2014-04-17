using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    abstract public class Solver
    {
        private Grid _board;
        public abstract Grid Solve(Grid initialGrid);

    }
}
