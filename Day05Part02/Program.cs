var input = File.ReadAllLines("input");
var ranges = input.TakeWhile(i => i.Length > 0).Select(GetRange).ToList();
while (MergeRanges());
var fresh = ranges.Sum(range => range.max - range.min + 1);

Console.WriteLine($"Fresh: {fresh}");
return;

(long min, long max) GetRange(string line)
{
    var split = line.Split('-');
    var min = long.Parse(split[0], CultureInfo.InvariantCulture);
    var max = long.Parse(split[1], CultureInfo.InvariantCulture);
    return (min, max);
}

bool MergeRanges()
{
    for (var i = 1; i < ranges.Count; i++)
    {
        for (var j = 0; j < i; j++)
        {
            if (ranges[i].min > ranges[j].max || ranges[i].max < ranges[j].min)
                continue;

            var min = Math.Min(ranges[i].min, ranges[j].min);
            var max = Math.Max(ranges[i].max, ranges[j].max);
            ranges.RemoveAt(i);
            ranges.RemoveAt(j);
            ranges.Add((min, max));
            return true;
        }
    }

    return false;
}
