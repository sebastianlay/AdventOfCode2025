var position = 50;
var password = 0;

var instructions = File.ReadAllLines("input");
foreach (var instruction in instructions)
{
    if (instruction.Length < 2)
        continue;

    if (!int.TryParse(instruction[1..], out var offset))
        continue;

    if (instruction[0] == 'L')
        offset *= -1;

    position += offset;
    position = (position % 100 + 100) % 100;

    if (position == 0)
        password++;
}

Console.WriteLine($"Password: {password}");
