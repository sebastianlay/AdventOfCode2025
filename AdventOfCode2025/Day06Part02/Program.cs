var input = File.ReadAllLines("input");
var numbers = new List<int>();
var total = 0L;

for (var i = input[0].Length - 1; i >= 0; i--)
{
    var concatenated = string.Empty;
    for (var j = 0; j < input.Length - 1; j++)
        concatenated += input[j][i];

    numbers.Add(int.Parse(concatenated));

    var operand = input[^1][i];

    if (operand == '+')
        total += numbers.Sum();
    else if (operand == '*')
        total += numbers.Aggregate(1L, (x, y) => x * y);

    if (operand != ' ')
    {
        numbers.Clear();
        i--;
    }
}

Console.WriteLine($"Total: {total}");
