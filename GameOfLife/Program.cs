using GameOfLife;
using GameOfLife.Processor;




void Run()
{

    var board = new Board(10, 10);

    board[0, 1] = true;

    board[1, 2] = true;

    board[2, 0] = true;

    board[2, 1] = true;

    board[2, 2] = true;

    Console.WriteLine(board);

    var processor = new BoardProcessor(board);

    var MoreThan3 = (Board board, int i, int j) => {
        var neighbours = board.GetNeighbours(i, j);
        return neighbours.Where(x => x).Count() > 3 && board[i,j];
    };

    var LessThan2 = (Board board, int i, int j) =>
    {
        var neighbours = board.GetNeighbours(i, j);
        return neighbours.Where(x => x).Count() < 2 && board[i,j];
    };

    var MoreThan3WhenDied = (Board board, int i, int j) =>
    {
        var neighbours = board.GetNeighbours(i, j);
        return neighbours.Where(x => x).Count() == 3 && !board[i, j];
    };

    var Born = (Board board, int i, int j) =>
    {
        board[i,j] = true;
    };

    var Die = (Board board, int i, int j) =>
    {
        board[i, j] = false;
    };

    processor.Rules.Add(new BoardProcessorRule(MoreThan3, Die, "Died then 3+ neighbours"));
    processor.Rules.Add(new BoardProcessorRule(LessThan2, Die, "Died then 1- neighbours"));
    processor.Rules.Add(new BoardProcessorRule(MoreThan3WhenDied, Born, "Born then 3+ neighbours"));

    foreach (var state in processor)
    {
        Console.Clear();
        Console.WriteLine(state);
        Thread.Sleep(200);
    }
}


Run();

