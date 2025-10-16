namespace AdventOfCode2023.Core.Day8;

internal static class MathUtils {

    internal static long LCM(IEnumerable<int> numbers)
    {
        return numbers.Aggregate(1L, (lcm, num) => LCM(lcm, num));
    }

    internal static long LCM(long a, long b)
    {
        return Math.Abs(a * b) / GCD(a, b);
    }

    internal static long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }


}