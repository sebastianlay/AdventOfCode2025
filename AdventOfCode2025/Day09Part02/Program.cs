var input = File.ReadAllLines("input");
var tiles = new List<(int X, int Y)>(input.Length);
var max = 0L;

foreach (var line in input)
{
    var parts = line.Split(',').Select(int.Parse).ToArray();
    tiles.Add((parts[0], parts[1]));
}

foreach (var rect in GetRects())
{
    if (GetEdges().Any(edge => Intersects(rect, edge)))
        continue;

    var width = Math.Abs(tiles[rect.A].X - tiles[rect.B].X) + 1L;
    var height = Math.Abs(tiles[rect.A].Y - tiles[rect.B].Y) + 1;
    max = Math.Max(max, width * height);
}

Console.WriteLine($"Max: {max}");
return;

IEnumerable<(int A, int B)> GetRects()
{
    for (var i = 0; i < tiles.Count; i++)
        for (var j = i + 1; j < tiles.Count; j++)
            yield return (i, j);
}

IEnumerable<(int A, int B)> GetEdges()
{
    for (var i = 0; i < tiles.Count; i++)
        yield return (i, (i + 1) % tiles.Count);
}

bool Intersects((int A, int B) rect, (int A, int B) edge)
{
    var right = Math.Min(tiles[edge.A].X, tiles[edge.B].X) >= Math.Max(tiles[rect.A].X, tiles[rect.B].X);
    var left  = Math.Max(tiles[edge.A].X, tiles[edge.B].X) <= Math.Min(tiles[rect.A].X, tiles[rect.B].X);
    var above = Math.Min(tiles[edge.A].Y, tiles[edge.B].Y) >= Math.Max(tiles[rect.A].Y, tiles[rect.B].Y);
    var below = Math.Max(tiles[edge.A].Y, tiles[edge.B].Y) <= Math.Min(tiles[rect.A].Y, tiles[rect.B].Y);

    return !(right || left || above || below);
}
