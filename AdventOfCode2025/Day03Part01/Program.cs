var sum = 0u;
var banks = File.ReadLines("input");

foreach (var bank in banks)
{
    var firstDigit = bank[..^1].Max();
    var index = bank.IndexOf(firstDigit) + 1;
    var secondDigit = bank[index..].Max();
    sum += uint.Parse(firstDigit.ToString() + secondDigit);
}

Console.WriteLine($"Sum: {sum}");
