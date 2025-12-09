var input = File.ReadAllLines("input");
var tiles = new List<(int X, int Y)>(input.Length);

foreach (var line in input)
{
    var parts = line.Split(',').Select(int.Parse).ToArray();
    tiles.Add((parts[0], parts[1]));
}

var max = 0L;
for (var i = 0; i < tiles.Count; i++)
{
    for (var j = i + 1; j < tiles.Count; j++)
    {
        var width = Math.Abs(tiles[i].X - tiles[j].X) + 1L;
        var height = Math.Abs(tiles[i].Y - tiles[j].Y) + 1;
        max = Math.Max(max, width * height);
    }
}

Console.WriteLine($"Max: {max}");
