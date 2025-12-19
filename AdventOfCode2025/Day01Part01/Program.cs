var position = 50;
var password = 0u;
var instructions = File.ReadAllLines("input");

foreach (var instruction in instructions)
{
    var offset = int.Parse(instruction[1..]);

    if (instruction[0] == 'L')
        offset *= -1;

    position += offset;
    position = (position % 100 + 100) % 100;

    if (position == 0)
        password++;
}

Console.WriteLine($"Password: {password}");
