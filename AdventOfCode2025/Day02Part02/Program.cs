var sum = 0L;
var regex = new Regex(@"^(.*)\1+$", RegexOptions.Compiled);
var input = File.ReadLines("input").First();

foreach (var range in input.Split(','))
{
    var ids = range.Split('-').Select(long.Parse).ToArray();
    sum += Range(ids[0], ids[1]).Where(IsInvalid).Sum();
}

Console.WriteLine($"Sum: {sum}");
return;

bool IsInvalid(long id) => regex.IsMatch(id.ToString());

static IEnumerable<long> Range(long start, long end)
{
    while (start <= end)
    {
        yield return start;
        start++;
    }
}
