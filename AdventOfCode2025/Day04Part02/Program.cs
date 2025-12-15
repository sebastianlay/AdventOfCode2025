var grid = File.ReadAllLines("input").Select(x => x.ToCharArray()).ToArray();
var w = grid[0].Length;
var h = grid.Length;
ushort sum = 0;

while (RemoveRolls());

Console.WriteLine($"Sum: {sum}");
return;

bool RemoveRolls()
{
    ushort removed = 0;

    for (byte y = 0; y < h; y++)
        for (byte x = 0; x < w; x++)
            removed += RemoveRoll(y, x);

    sum += removed;
    return removed > 0;
}

byte RemoveRoll(byte y, byte x)
{
    if (grid[y][x] != '@')
        return 0;

    byte adjacent = 0;

    for (var dy = y == 0 ? 0 : -1; dy <= (y == h - 1 ? 0 : 1); dy++)
    {
        for (var dx = x == 0 ? 0 : -1; dx <= (x == w - 1 ? 0 : 1); dx++)
        {
            if (dy == 0 && dx == 0)
                continue;

            if (grid[y + dy][x + dx] == '@' && ++adjacent == 4)
                return 0;
        }
    }

    grid[y][x] = 'x';
    return 1;
}
