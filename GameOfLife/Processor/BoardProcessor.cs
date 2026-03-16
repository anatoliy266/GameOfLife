using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Processor
{
    internal class BoardProcessor : IEnumerable<Board>
    {
        public BoardProcessorEnumerator Enumerator { get; private set; }

        public BoardProcessor(Board board)
        {
            Enumerator = new BoardProcessorEnumerator(board);
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
