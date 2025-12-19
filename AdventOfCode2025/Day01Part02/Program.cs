var position = 50;
var password = 0;
var instructions = File.ReadAllLines("input");

foreach (var instruction in instructions)
{
    var offset = int.Parse(instruction[1..]);

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
