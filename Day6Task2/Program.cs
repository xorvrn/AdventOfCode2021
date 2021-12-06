var s = Console.ReadLine();
var startData = s.Split(',').Select(x => byte.Parse(x)).ToList();

var data = new decimal[9];
for (int i = 0; i < startData.Count; i++)
{
    data[startData[i]]++;
}

for (int day = 0; day < 256; day++)
{
    var newFish = data[0];

    for (int i = 1; i < 9; i++)
    {
        data[i - 1] = data[i];
    }
    data[6] += newFish;
    data[8] = newFish;

}

Console.WriteLine(data.Sum());