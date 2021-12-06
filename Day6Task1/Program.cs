var s = Console.ReadLine();
var data = s.Split(',').Select(x => int.Parse(x)).ToList();

for (int d = 0; d < 80; d++)
{
    var len = data.Count;
    for (int i = 0; i < len; i++)
    {
        if (data[i] > 0)
        {
            data[i]--;
        }
        else if (data[i] == 0)
        {
            data[i] = 6;
            data.Add(8);
        }
    }
}

Console.WriteLine(data.Count);