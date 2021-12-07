var s = Console.ReadLine();
var positions = s.Split(',')
    .Select(int.Parse)
    .GroupBy(x => x)
    .ToDictionary(x => x.Key, x => x.Count());

var minPosition = positions.Keys.Min();
var maxPosition = positions.Keys.Max();

var costs = new int[maxPosition - minPosition + 1];
var cost = 0;
for (var i = 0; i < costs.Length; i++)
{
    cost += i;
    costs[i] = cost;
}

var min = int.MaxValue;

for (int p = minPosition; p <= maxPosition; p++)
{
    var localMin = 0;
    foreach (var position2 in positions)
    {
        localMin += costs[Math.Abs(position2.Key - p)] * position2.Value;
    }

    if (localMin < min)
    {
        min = localMin;
    }
}

Console.WriteLine(min);