const StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries;
var input = File.ReadAllLines("input");
var grid = input.Select(line => line.Split(' ', options)).ToArray();
var total = 0L;

for (var x = 0; x < grid[0].Length; x++)
{
    var operand = grid[^1][x][0];
    var subtotal = long.Parse(grid[0][x]);
    for (var y = 1; y < grid.Length - 1; y++)
        subtotal = operand == '+'
            ? subtotal + long.Parse(grid[y][x])
            : subtotal * long.Parse(grid[y][x]);

    total += subtotal;
}

Console.WriteLine($"Total: {total}");
