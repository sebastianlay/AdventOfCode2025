var sum = 0u;

var grid = File.ReadAllLines("input");
var width = grid[0].Length;
var height = grid.Length;

for (var y = 0; y < height; y++)
{
    for (var x = 0; x < width; x++)
    {
        if (grid[y][x] == '.')
            continue;

        var adjacent = 0u;

        // top left
        if (x > 0 && y > 0 && grid[y - 1][x - 1] == '@')
            adjacent++;

        // top middle
        if (y > 0 && grid[y - 1][x] == '@')
            adjacent++;

        // top right
        if (y > 0 && x < width - 1 && grid[y - 1][x + 1] == '@')
            adjacent++;

        // middle left
        if (x > 0 && grid[y][x - 1] == '@')
            adjacent++;

        // middle right
        if (x < width - 1 && grid[y][x + 1] == '@')
            adjacent++;

        // bottom left
        if (x > 0 && y < height - 1 && grid[y + 1][x - 1] == '@')
            adjacent++;

        // bottom middle
        if (y < height - 1 && grid[y + 1][x] == '@')
            adjacent++;

        // bottom right
        if (x < width - 1 && y < height - 1 && grid[y + 1][x + 1] == '@')
            adjacent++;

        if (adjacent < 4)
            sum++;
    }
}

Console.WriteLine($"Sum: {sum}");
