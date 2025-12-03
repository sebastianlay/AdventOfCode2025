var sum = 0;

var banks = File.ReadLines("input");
foreach (var bank in banks)
{
    var concatenated = string.Empty;
    var firstDigit = bank.Max();
    var firstDigitIndex = bank.IndexOf(firstDigit);

    if (firstDigitIndex == bank.Length - 1)
    {
        var secondDigit = bank[..firstDigitIndex].Max();
        concatenated = secondDigit.ToString() + firstDigit.ToString();
    }
    else
    {
        var secondDigit = bank[(firstDigitIndex + 1)..].Max();
        concatenated = firstDigit.ToString() + secondDigit.ToString();
    }

    if (int.TryParse(concatenated, out var parsed))
        sum += parsed;
}

Console.WriteLine($"Sum: {sum}");
