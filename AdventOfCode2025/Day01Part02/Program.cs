var position = 50;
var password = 0;

var instructions = File.ReadAllLines("input");
foreach (var instruction in instructions)
{
    if (instruction.Length < 2)
        continue;

    if (!int.TryParse(instruction[1..], out var offset))
        continue;

    password += offset / 100;

    if (instruction[0] == 'L')
        offset *= -1;

    var actual = offset % 100;
    position += actual;

    // cross zero when turning the dial right
    if (position < actual || position >= 100)
        password++;

    // cross zero when turning the dial left
    if (position <= 0 && position != actual)
        password++;

    position = (position % 100 + 100) % 100;
}

Console.WriteLine($"Password: {password}");
