var input = File.ReadAllLines("input");
const int height = 4;

// parsing the operations
var operations = new List<(bool isAdd, int width)>();
var searchValues = SearchValues.Create("+*");
var operands = input[height].AsSpan();
int index;
var cursor = 1;
var isAdd = operands[0] == '+';
while ((index = operands[cursor..].IndexOfAny(searchValues)) >= 0)
{
    operations.Add((isAdd, index));
    isAdd = operands[cursor + index] == '+';
    cursor += index + 1;
}
operations.Add((isAdd, operands.Length - cursor + 1));

// doing the actual calculations
var total = 0L;
var offset = 0;
foreach (var operation in operations)
{
    var subtotal = operation.isAdd ? 0L : 1L;
    for (var i = 0; i < operation.width; i++)
    {
        var number = string.Empty;
        for (var j = 0; j < height; j++)
            number += input[j][i + offset];

        var parsed = long.Parse(number, CultureInfo.InvariantCulture);
        if (operation.isAdd)
            subtotal += parsed;
        else
            subtotal *= parsed;
    }

    total += subtotal;
    offset += operation.width + 1;
}

Console.WriteLine($"Total: {total}");
