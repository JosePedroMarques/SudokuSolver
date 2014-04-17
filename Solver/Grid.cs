using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public class Grid
    {
        private int[] _grid = new int[81];
        private readonly int _size = 9;
      
        public int Size 
        {
            get { return _size; }
        }
        public Grid(int size, int initialCount)
        {
            _size = size;
            Initialize();
            Random r = new Random();
            var availablePos = _grid.Select((s,i) => new {i,s})
                                    .Where(p => p.s == 0)
                                    .Select(t=> t.i)
                                    .OrderBy(a => Guid.NewGuid()).ToList();
         
            for (int i = 0; i < initialCount; i++)
            {
                bool placed = false;
                while (!placed)
                {
                    int n = r.Next(1, size+1);
                    int pos = availablePos.First();
                    if (CanPlace(n,pos))
                    {
                        Place(n, pos);
                        availablePos.RemoveAt(0);
                        placed=true;
                    }
                }

            }

        }

        public Grid(Grid initialGrid)
        {
            for (int i = 0; i < initialGrid.Size*initialGrid.Size; i++)
            {
                _grid[i] = initialGrid._grid[i];
            }
            
        }

        public int GetNumPlaced()
        {
            return _grid.Where(p => p != 0).Count();
        }

        public int GetNumMistakes()
        {
            int sum = 0;
            for (int i = 0; i < _size*_size; i++)
            {
                int v = _grid[i];
                if (v != 0)
                {
                    _grid[i] = 0;
                    if (!CanPlace(v, i))
                        sum++;
                    _grid[i] = v;
                }
            }
            return sum;
        }

        public bool CanPlace(int x, int pos)
        {
            return CanPlace(x, pos/_size, pos%_size);
        }

        private void Initialize()
        {
            _grid = new int[_size*_size];
            for (int i = 0; i < _size*_size; i++)
                _grid[i] = 0;
        }

        public int Get(int row, int col)
        {
            return _grid[row*_size + col];
        }

        public void Place(int i, int row, int col)
        {
            _grid[row*_size + col] = i;
        }

        public void Place(int i, int pos)
        {
            Place(i,pos/_size,pos%_size);
        }

        public bool CanPlace(int x, int row, int col)
        { 
            return  _grid[row*_size+col]==0 && CanPlaceRow(x,row) && CanPlaceColumn(x,col) && CanPlaceSquare(x,row,col);
        }

        private bool CanPlaceSquare(int x, int row, int col)
        {
            int squareRow = row/3;
            int squareColumn = col/3;

            for(int i = 0; i < _size;i++)
                if(_grid[squareRow*3*_size + squareColumn*3 + i%3+9*(i/3)]==x)
                    return false;
            return true;
        }

        private bool CanPlaceColumn(int x, int col)
        {
            for(int i = 0; i < _size; i++ )
                if(_grid[i*_size+col]==x)
                    return false;
            return true;
        }

        private bool CanPlaceRow(int x, int row)
        {
            for (int i = 0; i < _size; i++)
                if (_grid[row*_size+i] == x)
                    return false;
            return true;
        }

        public bool IsSolved()
        {
            return GetNumPlaced() == _size*_size;
        }

        public List<int> GetEmptyPositions()
        {
            return _grid.Select((s, i) => new { i, s })
                                       .Where(p => p.s == 0)
                                       .Select(t => t.i)
                                      .ToList();
        } 

        public bool TryPlace(int x, int pos)
        {
            if (CanPlace(x, pos))
                Place(x, pos);
            else
                return false;
            return true;
        }

        public List<int> GetAvailableNumbersFor(int row, int col)
        {
            List<int> available = new List<int>();
            
            for (int i = 1; i <= _size; i++)
            {
                if(CanPlace(i,row,col))
                    available.Add(i);
            }
            return available;
        } 

        public List<int> GetAvailableNumbersFor(int pos)
        {
            return GetAvailableNumbersFor(pos/_size, pos%_size);
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < _size; i++)
            {
                if (i%3 == 0)
                    s += ("----------------------\n");
                for (int j = 0; j < _size; j++)
                {
                    if (j%3 == 0)
                        s += ("|");
                    

                    s += ( _grid[(i*_size + j)] + " ");
                }
                s += ("|\n");

            }
            return s;

        }


    }

}
