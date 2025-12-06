var input = File.ReadAllLines("input");
var operations = new List<(char operand, int width)>();
const int height = 4;

var operand = input[height][0];
var width = 1;
for (var i = 1; i < input[height].Length; i++)
{
    width++;

    if (i == input[height].Length - 1)
    {
        operations.Add((operand, width));
        continue;
    }

    if (input[height][i] == ' ')
        continue;

    operations.Add((operand, width - 2));
    operand = input[height][i];
    width = 1;
}

var total = 0L;
var offset = 0;
foreach (var operation in operations)
{
    var subtotal = operation.operand == '+' ? 0L : 1L;
    for (var i = 0; i < operation.width; i++)
    {
        var number = string.Empty;
        for (var j = 0; j < height; j++)
            number += input[j][i + offset];

        var parsed = long.Parse(number, CultureInfo.InvariantCulture);
        if (operation.operand == '+')
            subtotal += parsed;
        else
            subtotal *= parsed;
    }

    total += subtotal;
    offset += operation.width + 1;
}

Console.WriteLine($"Total: {total}");
