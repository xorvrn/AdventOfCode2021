var lines = File.ReadAllLines("input.txt");

var ysize = lines.Length + 2;
var xsize = lines[0].Length + 2;

var data = new int[ysize, xsize];

for (int i = 0; i < lines.Length; i++)
{
    var line = lines[i].Select(x => int.Parse(x.ToString())).ToArray();
    for (int j = 0; j < line.Length; j++)
    {
        data[i + 1, j + 1] = line[j];
    }
}

for (int i = 0; i < xsize; i++)
{
    data[0, i] = 9;
    data[ysize - 1, i] = 9;
}

for (int i = 0; i < ysize; i++)
{
    data[i, 0] = 9;
    data[i, xsize - 1] = 9;
}

var basins = new List<int>();
for (int i = 1; i < ysize - 1; i++)
{
    for (int j = 1; j < xsize - 1; j++)
    {
        if (data[i, j] < data[i - 1, j] && data[i, j] < data[i + 1, j] && data[i, j] < data[i, j - 1] && data[i, j] < data[i, j + 1])
        {
            basins.Add(GetBasinSize(0, i, j));
        }
    }
}

basins = basins.OrderByDescending(x => x).ToList();
var result = basins.Take(3).Aggregate((x, y) => x * y);
Console.WriteLine(result);

int GetBasinSize(int sum, int y, int x)
{
    if (data[y, x] == 9 || y == 0 || y == ysize || x == 0 || x == xsize)
    {
        return sum;
    }

    sum++;
    data[y, x] = 9;

    sum += GetBasinSize(0, y, x + 1);
    sum += GetBasinSize(0, y + 1, x);
    sum += GetBasinSize(0, y, x - 1);
    sum += GetBasinSize(0, y - 1, x);

    return sum;
}