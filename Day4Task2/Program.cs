const int boardSize = 5;

var lines = File.ReadAllLines("input.txt");

var queue = new Queue<int>(lines[0].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)));

var boards = new List<int[][]>();

var boardNum = 0;
var lineNum = 2;
while (lineNum < lines.Length)
{
    boards.Add(new int[boardSize + 1][]);
    for (int i = 0; i < boardSize; i++)
    {
        var tmp = lines[lineNum].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        boards[boardNum][i] = new int[boardSize + 1];
        Array.Copy(tmp, boards[boardNum][i], tmp.Length);

        boards[boardNum][i][boardSize] = tmp.Sum();
        lineNum++;
    }
    lineNum++;
    boardNum++;
}

for (int i = 0; i < boards.Count; i++)
{
    boards[i][boardSize] = new int[boardSize];
    for (int j = 0; j < boardSize; j++)
    {
        for (int k = 0; k < boardSize; k++)
        {
            boards[i][boardSize][j] += boards[i][k][j];
        }
    }
}

Console.WriteLine(Solve());

int Solve()
{
    var winBoards = new List<int>();
    while (true)
    {
        var val = queue.Dequeue();
        for (int i = 0; i < boards.Count; i++)
        {
            if (winBoards.Contains(i))
            {
                continue;
            }

            for (int j = 0; j < boardSize; j++)
            {
                for (int k = 0; k < boardSize; k++)
                {
                    if (boards[i][j][k] == val)
                    {
                        boards[i][j][k] = 0;
                        boards[i][j][boardSize] -= val;
                        boards[i][boardSize][k] -= val;

                        if (boards[i][j][boardSize] == 0 || boards[i][boardSize][k] == 0)
                        {
                            if (boards.Count - winBoards.Count == 1)
                            {
                                return boards[i].Where(x => x.Length == boardSize + 1).Sum(x => x[boardSize]) * val;
                            }
                            winBoards.Add(i);
                        }
                    }
                }
            }
        }
    }
}