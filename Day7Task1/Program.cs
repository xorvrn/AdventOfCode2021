var s = Console.ReadLine();
var positions = s.Split(',')
    .Select(int.Parse)
    .GroupBy(x => x)
    .ToDictionary(x => x.Key, x => x.Count());

var min = int.MaxValue;

foreach (var position in positions)
{
    var localMin = 0;
    foreach (var position2 in positions)
    {
        localMin += Math.Abs(position2.Key - position.Key) * position2.Value;
    }

    if (localMin < min)
    {
        min = localMin;
    }
}

Console.WriteLine(min);