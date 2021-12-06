var map = new Dictionary<Point, int>();
var s = Console.ReadLine();

while (!string.IsNullOrEmpty(s))
{
    var parts = s.Split(new[] { ' ', ',', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
    var point1 = new Point { X = int.Parse(parts[0]), Y = int.Parse(parts[1]) };
    var point2 = new Point { X = int.Parse(parts[2]), Y = int.Parse(parts[3]) };

    if (point1.Y == point2.Y)
    {
        for (int i = Math.Min(point1.X, point2.X); i <= Math.Max(point1.X, point2.X); i++)
        {
            var point = new Point { X = i, Y = point1.Y };
            AddPoint(point);
        }
    }
    else if (point1.X == point2.X)
    {
        for (int i = Math.Min(point1.Y, point2.Y); i <= Math.Max(point1.Y, point2.Y); i++)
        {
            var point = new Point { X = point1.X, Y = i };
            AddPoint(point);
        }
    }
    else
    {
        var dx = Math.Sign(point2.X - point1.X);
        var dy = Math.Sign(point2.Y - point1.Y);

        var point = point1;

        for (int i = Math.Min(point1.X, point2.X); i <= Math.Max(point1.X, point2.X); i++)
        {
            AddPoint(point);
            point.X += dx;
            point.Y += dy;
        }
    }

    s = Console.ReadLine();
}

Console.WriteLine(map.Count(x => x.Value > 1));

void AddPoint(Point point)
{
    if (map.ContainsKey(point))
    {
        map[point]++;
    }
    else
    {
        map.Add(point, 1);
    }
}

struct Point
{
    public int X;
    public int Y;
}