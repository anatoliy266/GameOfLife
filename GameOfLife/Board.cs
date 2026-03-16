using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    internal class Board
    {
        public Cell[,] Field { private get; set; }
        public Board(int m, int n)
        {
            Field = new Cell[m,n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Field[i,j] = new Cell() { Position = (i,j) };
                    
                }
            }

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    var neighbours = GetNeighbours(i, j);
                    foreach (var neighbour in neighbours)
                    {
                        if (neighbour.IsAlive) neighbour.NeighbourCount++;
                        Field[i, j].OnChanged += neighbour.OnNeighborChanged;
                    }
                }
            } 
        }

        public List<Cell> GetNeighbours(int i, int j)
        {
            var res = new List<Cell>();
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

        public void Change()
        {
            // Сначала все клетки смотрят на текущих соседей и решают свою судьбу
            foreach (var cell in Field) cell.Prepare();

            // Только когда ВСЕ решили, обновляем состояния (это обновит NeighbourCount для СЛЕДУЮЩЕГО хода)
            foreach (var cell in Field) cell.Update();
        }

        public Cell this[int m, int n]
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
            return new Board(Field.GetLength(0), Field.GetLength(1)) { Field = (Cell[,])Field.Clone() };
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < Field.GetLength(0); i++)
            {
                for (var j = 0; j < Field.GetLength(1); j++)
                {
                    if (Field[i,j].IsAlive == true)
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
