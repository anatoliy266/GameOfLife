using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace GameOfLife.Processor
{
    internal class BoardProcessorEnumerator : IEnumerator<Board>
    {

        public Board Current { get; set; }
        private BoardProcessor _processor;

        object IEnumerator.Current => Current;
        public BoardProcessorEnumerator(Board board, BoardProcessor boardProcessor)
        {
            Current = board;
            _processor = boardProcessor;
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

            for (var i = 0; i < board.Field.GetLength(0); i++)
            {
                for (var j = 0; j < board.Field.GetLength(1); j++)
                {
                    foreach (var rule in _processor.Rules)
                    {
                        if (rule.Condition(Current, i, j))
                        {
                            rule.Action(board, i, j);
                        } 
                    }
                }
            }


            Current = board;

            return true;
        }

        public void Reset()
        {

        }
    }
}