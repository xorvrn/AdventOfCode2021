var lines = File.ReadAllLines("input.txt");

var input = lines[0];

var rules = new Dictionary<string, string>();
{
    for (int i = 2; i < lines.Length; i++)
    {
        var parts = lines[i].Split(" -> ");
        rules.Add(parts[0], parts[1]);
    }
}

var elements = new Dictionary<string, ulong>();
for (int i = 0; i < input.Length; i++)
{
    SetValue(elements, $"{input[i]}", 1);
}

var pairs = new Dictionary<string, ulong>();
for (int i = 0; i < input.Length - 1; i++)
{
    var pair = input[i].ToString() + input[i + 1];
    SetValue(pairs, pair, 1);
}

for (int i = 0; i < 40; i++)
{
    var tmp = new Dictionary<string, ulong>();

    foreach (var pair in pairs)
    {
        if (rules.TryGetValue(pair.Key, out var element))
        {
            SetValue(elements, element, pair.Value);

            SetValue(tmp, $"{pair.Key[0]}{element}", pair.Value);
            SetValue(tmp, $"{element}{pair.Key[1]}", pair.Value);
        }
        else
        {
            SetValue(tmp, pair.Key, pair.Value);
        }
    }

    pairs = tmp;
}

foreach (var element in elements)
{
    Console.WriteLine($"{element.Key} - {element.Value}");
}

Console.WriteLine(elements.Max(x => x.Value) - elements.Min(x => x.Value));

void SetValue(IDictionary<string, ulong> dict, string key, ulong val)
{
    if (dict.ContainsKey(key))
    {
        dict[key] += val;
    }
    else
    {
        dict.Add(key, val);
    }
}