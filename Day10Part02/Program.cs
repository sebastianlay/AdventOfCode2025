var input = File.ReadAllLines("input");
var machines = input.Select(Parse);
var min = machines.Sum(Solve);

Console.WriteLine($"Min: {min}");
return;

static long Solve(Machine machine)
{
    var precomputed = GetPrecomputedValues(machine);
    return GetPresses(machine.Counters, precomputed);
}

static int GetPresses(int[] joltage, Precomputed precomputed)
{
    var result = 10_000;

    if (joltage.All(j => j == 0))
        return 0;

    if (joltage.Any(j => j < 0))
        return result;

    var parity = string.Join(',', joltage.Select(j => j % 2 == 0));
    if (!precomputed.Parities.TryGetValue(parity, out var combinations))
        return result;

    foreach (var combination in combinations)
    {
        var precomputedJoltage = precomputed.Joltages[combination];
        var newJoltage = new int[joltage.Length];
        for (var i = 0; i < joltage.Length; i++)
            newJoltage[i] = (joltage[i] - precomputedJoltage[i]) / 2;

        var combinationPresses = BitOperations.PopCount(combination);
        var presses = GetPresses(newJoltage, precomputed);
        var combinationResult = combinationPresses + 2 * presses;

        result = Math.Min(combinationResult, result);
    }

    return result;
}

static Precomputed GetPrecomputedValues(Machine machine)
{
    var parities = new Dictionary<string, List<uint>>();
    var joltages = new Dictionary<uint, int[]>();

    var combinations = Math.Pow(2, machine.Buttons.Length);
    for (var combination = 0u; combination < combinations; combination++)
    {
        var joltage = new int[machine.Counters.Length];
        for (var j = 0; j < machine.Buttons.Length; j++)
        {
            if ((combination & (1 << j)) <= 0)
                continue;

            foreach (var button in machine.Buttons[j])
                joltage[button] += 1;
        }

        var parity = string.Join(',', joltage.Select(j => j % 2 == 0));
        if (parities.TryGetValue(parity, out var value))
            value.Add(combination);
        else
            parities.Add(parity, [combination]);

        joltages.Add(combination, joltage);
    }

    return new Precomputed(parities, joltages);
}

static Machine Parse(string line)
{
    var buttons = line[(line.IndexOf(']') + 2)..(line.IndexOf('{') - 1)]
        .Split(' ')
        .Select(b => b[1..^1].Split(','))
        .Select(b => b.Select(int.Parse).ToArray())
        .ToArray();

    var counters = line[(line.IndexOf('{') + 1)..^1]
        .Split(',')
        .Select(int.Parse)
        .ToArray();

    return new Machine(buttons, counters);
}

internal sealed record Machine(int[][] Buttons, int[] Counters);

internal sealed record Precomputed(Dictionary<string, List<uint>> Parities, Dictionary<uint, int[]> Joltages);
