var s = Console.ReadLine();
var prev = int.Parse(s);
var count = 0;
while(!string.IsNullOrEmpty(s))
{
    var next = int.Parse(s);
    if (next > prev)
    {
        count++;
    }
    prev = next;
    s = Console.ReadLine();
}

Console.WriteLine(count);