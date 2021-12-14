var lines = File.ReadAllLines("input.txt");
var points = new List<(int X, int Y)>();
var rules = new List<(string, int)>();
foreach (var line in lines)
{
    var parts = line.Split(',');
    if (parts.Length != 2)
    {
        if (line.StartsWith("fold along"))
        {
            parts = line.Replace("fold along ", string.Empty).Split("=");
            rules.Add(new (parts[0], int.Parse(parts[1])));
        }
        continue;
    }
    points.Add(new (int.Parse(parts[0]), int.Parse(parts[1])));
}

var maxX = points.Max(x => x.X) + 1;
var maxY = points.Max(x => x.Y) + 1;

var map = new byte[maxY, maxX];
foreach (var point in points)
{
    map[point.Y, point.X] = 1;
}

foreach (var rule in rules)
{
    if (rule.Item1 == "x")
    {
        for (int i = 0; i < maxY; i++)
        {
            var dx = rule.Item2;
            for (int j = rule.Item2; j < maxX; j++)
            {
                if (map[i, j] == 1)
                {
                    map[i, dx] = 1;
                }
                dx--;
            }
        }
        maxX = rule.Item2;
    }
    else
    {
        var dy = rule.Item2;
        for (int i = rule.Item2; i < maxY; i++)
        {
            for (int j = 0; j < maxX; j++)
            {
                if (map[i, j] == 1) {
                    map[dy, j] = 1;
                }                
            }
            dy--;
        }
        maxY = rule.Item2;
    }
}

Console.WriteLine();

var count = 0;
for (int i = 0; i < maxY; i++)
{
    for (int j = 0; j < maxX; j++)
    {
        Console.Write(map[i, j] == 1 ? '#' : '.');
        if (map[i, j] == 1)
        {
            count++;
        }
    }
    Console.WriteLine();
}

Console.WriteLine(count);