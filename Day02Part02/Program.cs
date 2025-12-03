using System.Globalization;
using System.Text.RegularExpressions;

namespace Day02Part02;

internal static partial class Program
{
    [GeneratedRegex(@"^(.*)\1+$")]
    private static partial Regex IsInvalidRegex();

    public static void Main()
    {
        var sum = 0L;
        var input = File.ReadLines("input").First();
        foreach (var range in input.Split(','))
        {
            var ids = range.Split('-');
            if (!long.TryParse(ids[0], out var min) || !long.TryParse(ids[1], out var max))
                continue;

            sum += Range(min, max).Where(IsInvalid).Sum();
        }

        Console.WriteLine($"Sum: {sum}");
    }

    private static bool IsInvalid(long id)
    {
        var str = id.ToString(CultureInfo.InvariantCulture);
        return IsInvalidRegex().IsMatch(str);
    }

    private static IEnumerable<long> Range(long start, long end)
    {
        while (start <= end)
        {
            yield return start;
            start++;
        }
    }
}
