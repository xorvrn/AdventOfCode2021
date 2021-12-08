var s = Console.ReadLine();

var count = 0;
while (!string.IsNullOrEmpty(s))
{
    var parts = s.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
    var targetDigits = parts.Take(10).Where(x => IsKnownDigit(new HashSet<char>(x.ToCharArray()).Count)).ToArray();
    var output = parts.Skip(10).Take(4).ToArray();
    var matches = output.Where(x => targetDigits.Any(y => IsEquals(x, y))).ToArray();
    count += matches.Length;

    s = Console.ReadLine();
}

Console.WriteLine(count);

bool IsKnownDigit(int len)
{
    switch (len)
    {
        case 2: return true; // 1 - 2
        case 4: return true; // 4 - 4
        case 3: return true; // 7 - 3
        case 7: return true; // 8 - 7
    }
    return false;
}

bool IsEquals(string? x, string? y)
{
    if (x.Length != y.Length)
    {
        return false;
    }
    var a = x.ToCharArray();
    var b = y.ToCharArray();

    return a.All(x => b.Contains(x));
}