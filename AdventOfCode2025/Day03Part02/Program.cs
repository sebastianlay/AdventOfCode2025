const int rounds = 12;
var sum = 0L;
var banks = File.ReadLines("input");

foreach (var bank in banks)
{
    var concatenated = string.Empty;
    var cursor = 0;

    for (var i = rounds - 1; i >= 0; i--)
    {
        var digit = bank[cursor..^i].Max();
        var index = bank[cursor..^i].IndexOf(digit);

        concatenated += digit;
        cursor += index + 1;
    }

    sum += long.Parse(concatenated);
}

Console.WriteLine($"Sum: {sum}");
