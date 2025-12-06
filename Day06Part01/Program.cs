var input = File.ReadAllLines("input");
const StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
var grid = input.Select(line => line.Split(' ', options)).ToArray();
var width = grid[0].Length;
var height = grid.Length;
var total = 0L;

for (var x = 0; x < width; x++)
{
    var operand = grid[^1][x][0];
    var subtotal = long.Parse(grid[0][x], CultureInfo.InvariantCulture);
    for (var y = 1; y < height - 1; y++)
    {
        switch (operand)
        {
            case '+':
                subtotal += long.Parse(grid[y][x], CultureInfo.InvariantCulture);
                break;
            case '*':
                subtotal *= long.Parse(grid[y][x], CultureInfo.InvariantCulture);
                break;
        }
    }

    total += subtotal;
}

Console.WriteLine($"Total: {total}");
