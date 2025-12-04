namespace Day04Part02;

internal static class Program
{
    public static void Main()
    {
        var grid = File.ReadAllLines("input").Select(x => x.ToCharArray()).ToArray();
        var width = grid[0].Length;
        var height = grid.Length;
        var sum = 0u;
        var offsets = new (int dx, int dy)[]
        {
            (-1, -1), (0, -1), (1, -1),
            (-1,  0),          (1,  0),
            (-1,  1), (0,  1), (1,  1),
        };

        while (RemoveRolls(grid, width, height, offsets, ref sum));
        Console.WriteLine($"Sum: {sum}");
    }

    private static bool RemoveRolls(char[][] grid, int width, int height, (int, int)[] offsets, ref uint sum)
    {
        var removed = 0u;

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                if (grid[y][x] != '@')
                    continue;

                var adjacent = 0u;

                foreach (var (dx, dy) in offsets)
                {
                    if (grid.At(x + dx, y + dy) == '@')
                        adjacent++;
                }

                if (adjacent >= 4)
                    continue;

                grid[y][x] = 'x';
                removed++;
            }
        }

        sum += removed;
        return removed > 0;
    }

    private static char At(this char[][] grid, int x, int y)
    {
        if (y < 0 || y >= grid.Length)
            return ' ';

        if (x < 0 || x >= grid[y].Length)
            return ' ';

        return grid[y][x];
    }
}
