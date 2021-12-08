namespace Day8Task2
{
    public static class StringExtensions
    {
        public static string GetDifference(this string x, string y)
        {
            var a = x.ToCharArray();
            var b = y.ToCharArray();

            var result = new string(a.Where(x => !b.Contains(x)).ToArray());
            return result;
        }

        public static bool IsEquals(this string x, string y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }
            var a = x.ToCharArray();
            var b = y.ToCharArray();

            return a.All(x => b.Contains(x));
        }
    }
}
