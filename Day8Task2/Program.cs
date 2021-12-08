namespace Day8Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();

            var count = 0;
            while (!string.IsNullOrEmpty(s))
            {
                var parts = s.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                var input = parts.Take(10).ToArray();

                var knownDigits = input.Select(x => IsKnownDigit(x)).Where(x => x != null).ToDictionary(x => x.Key, x => x.Value);
                var d9 = parts
                    .Take(10)
                    .Where(x => x.Length == 6 &&  x.GetDifference(knownDigits[1]).GetDifference(knownDigits[4]).GetDifference(knownDigits[7]).Length == 1);
                knownDigits[9] = d9.First();

                var d0 = input.Where(x => x.Length == 6 && x != knownDigits[9] && knownDigits[1].GetDifference(x).Length == 0);
                knownDigits[0] = d0.First();

                var d6 = input.Where(x => x.Length == 6 && x != knownDigits[0] && x != knownDigits[9]);
                knownDigits[6] = d6.First();

                var d2 = input.Where(x => x.Length == 5 && x.GetDifference(knownDigits[9]).Length == 1);
                knownDigits[2] = d2.First();

                var d3 = input.Where(x => x.Length == 5 && x != knownDigits[2] && x.GetDifference(knownDigits[6]).Length == 1);
                knownDigits[3] = d3.First();

                var d5 = input.Where(x => x.Length == 5 && x != knownDigits[2] && x != knownDigits[3]);
                knownDigits[5] = d5.First();

                var output = parts.Skip(10).Take(4).ToArray();
                var matches = output.Select(x => knownDigits.First(d => d.Value.IsEquals(x)).Key).ToArray();
                var localSum = 0;
                var multiplicator = 1;
                for (int i = matches.Length - 1; i >= 0; i--)
                {
                    localSum += matches[i] * multiplicator;
                    multiplicator *= 10;
                }

                count += localSum;

                s = Console.ReadLine();
            }

            Console.WriteLine(count);
        }

        static Pair? IsKnownDigit(string s)
        {
            var len = new HashSet<char>(s.ToCharArray()).Count;
            switch (len)
            {
                case 2: return new Pair(1, s); // 1 - 2
                case 4: return new Pair(4, s); // 4 - 4
                case 3: return new Pair(7, s); // 7 - 3
                case 7: return new Pair(8, s); // 8 - 7
            }
            return null;
        }

        private record class Pair(int Key, string Value);
    }
}
