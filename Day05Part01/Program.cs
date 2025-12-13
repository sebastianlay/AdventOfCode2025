var input = File.ReadAllLines("input");
var empty = input.IndexOf(string.Empty);
var ranges = new List<(long Min, long Max)>();

foreach (var range in input[..empty])
{
    var split = range.Split('-').Select(long.Parse).ToArray();
    ranges.Add((split[0], split[1]));
}

var fresh = input[(empty + 1)..]
    .Select(long.Parse)
    .Count(i => ranges.Any(r => i >= r.Min && i <= r.Max));

Console.WriteLine($"Fresh: {fresh}");
