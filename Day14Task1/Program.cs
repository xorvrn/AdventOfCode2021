using System.Text;

var lines = File.ReadAllLines("input.txt");

var input = new StringBuilder(lines[0]);

var rules = new Dictionary<string, string>();
{
    for (int i = 2; i < lines.Length; i++)
    {
        var parts = lines[i].Split(" -> ");
        rules.Add(parts[0], parts[1]);
    }
}

for (int i = 0; i < 10; i++)
{
    var index = 0;
    while (index < input.Length - 1)
    {
        var pair = input[index].ToString() + input[index + 1];
        if (rules.TryGetValue(pair, out var element))
        {
            input.Insert(index + 1, element);
            index++;
        }
        index++;
    }
    Console.WriteLine(i);
}

var groups = input.ToString().GroupBy(x => x);
Console.WriteLine(groups.Max(x => x.Count()) - groups.Min(x => x.Count()));