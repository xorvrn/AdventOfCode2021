var mas = new int[4];

for (int i = 1; i < mas.Length; i++)
{
    mas[i] = int.Parse(Console.ReadLine());
}

var s = Console.ReadLine();
var count = 0;

do
{
    for (int i = 0; i < mas.Length - 1; i++)
    {
        mas[i] = mas[i + 1];
    }

    mas[mas.Length - 1] = int.Parse(s);

    if (mas[1] + mas[2] + mas[3] > mas[0] + mas[1] + mas[2])
    {
        count++;
    }

    s = Console.ReadLine();
} while (!string.IsNullOrEmpty(s));

Console.WriteLine(count);