using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public class BacktrackingSolver : Solver
    {
        public  override Grid Solve(Grid initial)
        {
            if (SolveAux(initial))
                return initial;
            return null;
        }

        private bool SolveAux(Grid initial)
        {
            if (initial.IsSolved())
                return true;
            int pos = GetNextPosition(initial);
            var listMoves = initial.GetAvailableNumbersFor(pos);
            foreach (var move in listMoves)
            {
                initial.Place(move,pos);
                if (SolveAux(initial))
                    return true;
                initial.Place(0,pos);

            }
            return false;
        }

        public int GetNextPosition(Grid g)
        {
            int min = int.MaxValue;
            int minPos = -1;
            for(int i = 0; i < g.Size; i++)
                for (int j = 0; j < g.Size; j++)
                {
                    if (g.Get(i, j) != 0)
                        continue;
                    var l = g.GetAvailableNumbersFor(i, j);
                    if (l.Count < min)
                    {
                        min = l.Count;
                        minPos = i*g.Size + j;

                    }
                    if (min == 1)
                        return minPos;
                }

            return minPos;
        }
    }
}
