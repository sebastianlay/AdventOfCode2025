using System.Globalization;

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
return;

bool IsInvalid(long id)
{
    var str = id.ToString(CultureInfo.InvariantCulture);
    var length = str.Length;
    return length % 2 == 0 && str[..(length / 2)] == str[(length / 2)..];
}

IEnumerable<long> Range(long start, long end)
{
    while (start <= end)
    {
        yield return start;
        start++;
    }
}
