using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static GameOfLife.Processor.BoardProcessorRule;

namespace GameOfLife.Processor
{
    internal class BoardProcessor : IEnumerable<Board>
    {
        public BoardProcessorEnumerator Enumerator { get; private set; }
        public List<BoardProcessorRule> Rules { get; set; } = new List<BoardProcessorRule>();

        public BoardProcessor(Board board)
        {
            Enumerator = new BoardProcessorEnumerator(board, this);
        }

        public IEnumerator<Board> GetEnumerator()
        {
            return Enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
