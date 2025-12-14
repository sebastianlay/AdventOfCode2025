var input = File.ReadAllLines("input");
var ranges = input.TakeWhile(i => i.Length > 0).Select(GetRange).ToList();
while (MergeRanges());
var fresh = ranges.Sum(range => range.Max - range.Min + 1);

Console.WriteLine($"Fresh: {fresh}");
return;

(long Min, long Max) GetRange(string line)
{
    var split = line.Split('-').Select(long.Parse).ToArray();
    return (split[0], split[1]);
}

bool MergeRanges()
{
    for (var i = 1; i < ranges.Count; i++)
    {
        for (var j = 0; j < i; j++)
        {
            if (ranges[i].Min > ranges[j].Max || ranges[i].Max < ranges[j].Min)
                continue;

            var min = Math.Min(ranges[i].Min, ranges[j].Min);
            var max = Math.Max(ranges[i].Max, ranges[j].Max);
            ranges.RemoveAt(i);
            ranges.RemoveAt(j);
            ranges.Add((min, max));
            return true;
        }
    }

    return false;
}
