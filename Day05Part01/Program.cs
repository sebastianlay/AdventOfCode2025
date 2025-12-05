var input = File.ReadAllLines("input");
var empty = input.IndexOf(string.Empty);
var ranges = new List<(long min, long max)>();

foreach (var range in input[..empty])
{
    var split = range.Split('-');
    if (long.TryParse(split[0], out var min) && long.TryParse(split[1], out var max))
        ranges.Add((min, max));
}

var fresh = input[(empty + 1)..]
    .Select(long.Parse)
    .Count(i => ranges.Any(r => i >= r.min && i <= r.max));

Console.WriteLine($"Fresh: {fresh}");
