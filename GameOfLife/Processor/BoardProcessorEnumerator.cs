using System.Collections;

namespace GameOfLife.Processor
{
    internal class BoardProcessorEnumerator : IEnumerator<Board>
    {
        
        public Board Current { get; set; }

        object IEnumerator.Current => Current;
        public BoardProcessorEnumerator(Board board)
        {
            Current = board;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
        }

        public bool MoveNext()
        {
            var board = Current.Copy();

            board.Change();
            
            Current = board;

            return true;
        }

        public void Reset()
        {
            
        }
    }
}