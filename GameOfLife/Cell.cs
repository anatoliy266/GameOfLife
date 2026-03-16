using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    internal class Cell
    {
        public (int i, int j) Position { get; internal set; }
        public bool IsAlive { get; set; }
        public int NeighbourCount { get; set; }

        public event Action<Cell>? OnChanged;
        private bool _nextState;

        public void Prepare()
        {
            if (IsAlive)
                _nextState = (NeighbourCount == 2 || NeighbourCount == 3);
            else
                _nextState = (NeighbourCount == 3);
        }

        public void Update()
        {
            if (_nextState != IsAlive)
            {
                IsAlive = _nextState;
                OnChanged?.Invoke(this);
            }
        }

        public void OnNeighborChanged(Cell cell)
        {
            if (cell.IsAlive) NeighbourCount++;
            else NeighbourCount--;
        }

        public void Born()
        {
            IsAlive = true;
            OnChanged?.Invoke(this);
        }
    }
}
