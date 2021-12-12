const string StartPoint = "start";
const string EndPoint = "end";

var linksList = new List<Link>();
var lines = File.ReadAllLines("input.txt");
foreach (var line in lines)
{
    var parts = line.Split('-');
    linksList.Add(new Link(parts[0], parts[1]));
}

var links = linksList.ToArray();
var startPoint = links.Where(x => x.Start == StartPoint || x.End == EndPoint);

var paths = new List<string>();

FindPath(StartPoint, new List<string>());

foreach (var path in paths)
{
    Console.Write(path);
    Console.Write($",{EndPoint}");
    Console.WriteLine();
}

void FindPath(string point, List<string> path)
{
    if (!CanVisit(point, path))
    {
        return;
    }

    path.Add(point);

    for (int i = 0; i < links.Length; i++)
    {
        if (links[i].Start != point && links[i].End != point) // skip not linked
        {
            continue;
        }

        if (links[i].Start == EndPoint || links[i].End == EndPoint)
        {
            var s = string.Join(',', path);
            paths.Add(s);
            continue;
        }

        if (links[i].Start == point)
        {
            FindPath(links[i].End, path);
        }
        else if (links[i].End == point)
        {
            FindPath(links[i].Start, path);
        }
    }

    if (path.Count > 0)
    {
        path.RemoveAt(path.Count - 1);
    }
}

bool CanVisit(string point, List<string> path)
{
    if ((point == StartPoint || point == EndPoint) && path.Contains(point))
    {
        return false;
    }

    if (IsLower(point) && path.Contains(point))
    {
        return !path.Where(x => IsLower(x)).GroupBy(x => x).Any(x => x.Count() > 1);

    }

    return true;
}

bool IsLower(string str)
{
    return str.All(c => char.IsLower(c));
}
record struct Link(string Start, string End);