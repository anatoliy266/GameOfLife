using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    internal class Board
    {
        public bool[,] Field { get; set; }
        public Board(int m, int n)
        {
            Field = new bool[m,n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Field[i,j] = false;
                    
                }
            }
        }

        public List<bool> GetNeighbours(int i, int j)
        {
            var res = new List<bool>();
            for (var m = i - 1; m <= i + 1; m++)
            {
                for (var n = j - 1; n <= j + 1; n++)
                {
                    if (m == i && n == j) continue;
                    res.Add(this[m, n]);
                }
            }
            return res;
        }

        

        public bool this[int m, int n]
        {
            get {
                int rows = Field.GetLength(0);
                int cols = Field.GetLength(1);

                int wrappedM = (m % rows + rows) % rows;
                int wrappedN = (n % cols + cols) % cols;

                return Field[wrappedM, wrappedN];
            }   
            set { Field[m, n] = value; }  
        }

        public Board Copy() {
            return new Board(Field.GetLength(0), Field.GetLength(1)) { Field = (bool[,])Field.Clone() };
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Field.GetLength(0); i++)
            {
                for (var j = 0; j < Field.GetLength(1); j++)
                {
                    if (Field[i,j] == true)
                    {
                        sb.Append("+");
                    } else
                    {
                        sb.Append(" ");
                    }
                    
                    
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
    }
}
