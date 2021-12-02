var x = 0;
var y = 0;
var aim = 0;

var s = Console.ReadLine();

while (!string.IsNullOrEmpty(s))
{
    var parts = s.Split(' ');
    var val = int.Parse(parts[1]);
    switch (parts[0])
    {
        case "forward":
            x += val;
            y += val * aim;
            break;
        case "down":
            aim += val;
            break;
        case "up":
            aim -= val;
            break;
    }

    s = Console.ReadLine();
}

Console.WriteLine(x * y);