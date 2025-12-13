var input = File.ReadAllLines("input").AsSpan();
var lastEmpty = input.LastIndexOf(string.Empty);

var areas = new List<int>();
var shapes = input[..lastEmpty];
foreach (var range in shapes.Split(string.Empty))
    areas.Add(input[range].ToArray().Sum(shape => shape.Count(c => c == '#')));

var result = 0;
var regions = input[(lastEmpty + 1)..];
foreach (var region in regions)
{
    var area = int.Parse(region[..2]) * int.Parse(region[3..5]);
    var necessary = 0;
    var indexes = region[7..].Split(' ').Select(int.Parse).ToArray();
    for (var i = 0; i < indexes.Length; i++)
        necessary += indexes[i] * areas[i];

    if (necessary <= area)
        result++;
}

Console.WriteLine($"Result: {result}");
