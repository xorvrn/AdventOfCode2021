var data = new List<string>();
var s = Console.ReadLine();
while (!string.IsNullOrEmpty(s))
{
    data.Add(s);
    s = Console.ReadLine();
}

var o2 = Processor(data, (x, y) => x >= y);
var co2 = Processor(data, (x, y) => x < y);

string Processor(List<string> data, Func<int, int, bool> comparer)
{
    var index = 0;
    do
    {
        var one = data.Where(x => x[index] == '1').ToList();
        var zero = data.Where(x => x[index] == '0').ToList();

        data = comparer(one.Count, zero.Count) ? one : zero;

        index++;
    } while (data.Count > 1);

    return data.First();
}

Console.WriteLine(Convert.ToInt32(o2, 2) * Convert.ToInt32(co2, 2));