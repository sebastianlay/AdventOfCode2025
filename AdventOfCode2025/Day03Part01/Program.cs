var sum = 0;
var banks = File.ReadLines("input");

foreach (var bank in banks)
{
    var firstDigit = bank.Max();
    var firstDigitIndex = bank.IndexOf(firstDigit);

    if (firstDigitIndex == bank.Length - 1)
    {
        var secondDigit = bank[..firstDigitIndex].Max();
        sum += int.Parse(secondDigit.ToString() + firstDigit);
    }
    else
    {
        var secondDigit = bank[(firstDigitIndex + 1)..].Max();
        sum += int.Parse(firstDigit.ToString() + secondDigit);
    }
}

Console.WriteLine($"Sum: {sum}");
