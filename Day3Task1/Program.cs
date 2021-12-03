var s = Console.ReadLine();
var mas = new int[s.Length];

while (!string.IsNullOrEmpty(s))
{
    for (int i = 0; i < mas.Length; i++)
    {
        if (s[i] == '0')
        {
            mas[i]--;
        }
        else
        {
            mas[i]++;
        }
    }

    s = Console.ReadLine();
}

var gamma = string.Join("", mas.Select(x => x > 0 ? '1' : '0'));
var epsilon = string.Join("", mas.Select(x => x > 0 ? '0' : '1'));

Console.WriteLine(Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2));