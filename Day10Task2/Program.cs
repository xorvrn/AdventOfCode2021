var points = new Dictionary<char, uint>
{
    { '(', 1 },
    { '[', 2 },
    { '{', 3 },
    { '<', 4 }
};

var linesPoints = new List<ulong>();

var s = Console.ReadLine();
while (!string.IsNullOrEmpty(s))
{
    var stack = new Stack<char>();
    var isValidLine = true;

    for (int i = 0; i < s.Length && isValidLine; i++)
    {
        switch (s[i])
        {
            case '(':
            case '[':
            case '{':
            case '<':
                stack.Push(s[i]);
                break;
            case ')':
            case ']':
            case '}':
            case '>':
                var bracket = stack.Pop();
                if (!ValidBracketPair(bracket, s[i]))
                {
                    isValidLine = false;
                }
                break;
        }
    }

    if (isValidLine && stack.Count > 0)
    {
        ulong linePoints = 0;
        while (stack.Count > 0)
        {
            var bracket = stack.Pop();
            linePoints *= 5;
            linePoints += points[bracket];
        }
        linesPoints.Add(linePoints);
    }

    s = Console.ReadLine();
}

linesPoints = linesPoints.OrderBy(x => x).ToList();
var middle = linesPoints[linesPoints.Count / 2];
Console.WriteLine(middle);

bool ValidBracketPair(char bracketPrev, char bracketLast)
{
    switch (bracketLast)
    {
        case ')':
            {
                return bracketPrev == '(';
            }
        case ']':
            {
                return (bracketPrev == '[');
            }
        case '}':
            return (bracketPrev == '{');
        case '>':
            return (bracketPrev == '<');
    }
    return false;
}

