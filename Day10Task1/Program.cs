var points = new Dictionary<char, int>
{
    { ')', 3 },
    { ']', 57 },
    { '}', 1197 },
    { '>', 25137 }
};

var totalPoints = 0;

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
                    totalPoints += points[s[i]];
                    isValidLine = false;
                }
                break;
        }
    }

    s = Console.ReadLine();
}

Console.WriteLine(totalPoints);

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

