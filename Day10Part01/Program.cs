var input = File.ReadAllLines("input");
var machines = input.Select(Parse);
var min = machines.Sum(Solve);

Console.WriteLine($"Min: {min}");
return;

static int Solve(Machine machine)
{
    var presses = 0;

    while (true)
    {
        var empty = new int[machine.Buttons.Length];
        var combinations = GetCombinations(0, ++presses, empty);
        if (combinations.Any(combination => ApplyCombination(machine, combination)))
            return presses;
    }
}

static bool ApplyCombination(Machine machine, int[] combination)
{
    var appliedLights = new bool[machine.Lights.Length];

    for (var i = 0; i < combination.Length; i++)
    {
        if (combination[i] % 2 == 0)
            continue;

        foreach (var button in machine.Buttons[i])
            appliedLights[button] = !appliedLights[button];
    }

    return machine.Lights.SequenceEqual(appliedLights);
}

static IEnumerable<int[]> GetCombinations(int index, int remaining, int[] values)
{
    if (index == values.Length - 1)
    {
        values[index] = remaining;
        yield return values;
        yield break;
    }

    for (var take = 0; take <= remaining; take++)
    {
        values[index] = take;
        var combinations = GetCombinations(index + 1, remaining - take, values);
        foreach (var combination in combinations)
            yield return combination;
    }
}

static Machine Parse(string line)
{
    var lights = line[1..line.IndexOf(']')]
        .Select(c => c == '#')
        .ToArray();

    var buttons = line[(line.IndexOf(']') + 2)..(line.IndexOf('{') - 1)]
        .Split(' ')
        .Select(b => b[1..^1].Split(','))
        .Select(b => b.Select(int.Parse).ToArray())
        .ToArray();

    return new Machine(lights, buttons);
}

internal sealed record Machine(bool[] Lights, int[][] Buttons);
