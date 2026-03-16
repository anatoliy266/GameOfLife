using GameOfLife;
using GameOfLife.Processor;


void Run()
{

    var board = new Board(10, 10);

    board[0, 1].IsAlive = true;
    board[0, 1].Born();
    board[1, 2].IsAlive = true;
    board[1, 2].Born();
    board[2, 0].IsAlive = true;
    board[2, 0].Born();
    board[2, 1].IsAlive = true;
    board[2, 1].Born();
    board[2, 2].IsAlive = true;
    board[2, 2].Born();

    board.Change();

    Console.WriteLine(board);

    var processor = new BoardProcessor(board);
    foreach (var state in processor)
    {
        Console.Clear();
        Console.WriteLine(state);
        Thread.Sleep(200);
    }
}

Run();

