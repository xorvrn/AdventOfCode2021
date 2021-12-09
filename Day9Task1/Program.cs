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

var sum = 0;
for (int i = 1; i < ysize - 1; i++)
{
    for (int j = 1; j < xsize - 1; j++)
    {
        if (data[i, j] < data[i - 1, j] && data[i, j] < data[i + 1, j] && data[i, j] < data[i, j - 1] && data[i, j] < data[i, j + 1])
        {
            sum += data[i, j] + 1;
        }
    }
}

Console.WriteLine(sum);