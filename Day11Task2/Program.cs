var lines = File.ReadAllLines("input.txt");

var ysize = lines.Length;
var xsize = lines[0].Length;

var data = new int[ysize, xsize];

for (int i = 0; i < lines.Length; i++)
{
    var line = lines[i].Select(x => int.Parse(x.ToString())).ToArray();
    for (int j = 0; j < line.Length; j++)
    {
        data[i, j] = line[j];
    }
}

var day = 0;
while (true)
{
    day++;

    var points = new List<(int y, int x)>();

    for (int i = 0; i < ysize; i++)
    {
        for (int j = 0; j < xsize; j++)
        {
            if (data[i, j] < 0)
            {
                data[i, j] = 0;
            }

            data[i, j]++;

            if (data[i, j] > 9)
            {
                points.Add(new(i, j));
            }
        }
    }

    var flashCount = points.Count;
    for (int i = 0; i < points.Count; i++)
    {
        IncAround(points[i].y, points[i].x);
    }

    points = GetCriticalPoints();
    while (points.Count > 0)
    {
        flashCount += points.Count;
        for (int i = 0; i < points.Count; i++)
        {
            IncAround(points[i].y, points[i].x);
        }

        points = GetCriticalPoints();
    }

    if (flashCount == ysize * xsize)
    {
        break;
    }
}

Console.WriteLine(day);

List<(int y, int x)> GetCriticalPoints()
{
    var points = new List<(int y, int x)>();
    for (int i = 0; i < ysize; i++)
    {
        for (int j = 0; j < xsize; j++)
        {
            if (data[i, j] > 9)
            {
                points.Add(new(i, j));
            }
        }
    }
    return points;
}

void IncAround(int y, int x)
{
    data[y, x] = -1;

    for (int i = -1; i <= 1; i++)
    {
        for (int j = -1; j <= 1; j++)
        {
            IncValue(y + i, x + j);
        }
    }
}


void IncValue(int y, int x)
{
    if (y >= 0 && y < ysize && x >= 0 && x < xsize && data[y, x] > 0)
    {
        data[y, x]++;
    }
}