var sum = 0L;
var input = File.ReadLines("input").First();

foreach (var range in input.Split(','))
{
    var ids = range.Split('-').Select(long.Parse).ToArray();
    sum += Range(ids[0], ids[1]).Where(IsInvalid).Sum();
}

Console.WriteLine($"Sum: {sum}");
return;

static bool IsInvalid(long id)
{
    var str = id.ToString();
    var length = str.Length;
    return length % 2 == 0 && str[..(length / 2)] == str[(length / 2)..];
}

static IEnumerable<long> Range(long start, long end)
{
    while (start <= end)
        yield return start++;
}
