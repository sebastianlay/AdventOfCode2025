var input = File.ReadAllLines("input");
var boxes = new List<(int X, int Y, int Z)>(input.Length);
const int pairs = 1000;

foreach (var line in input)
{
    var split = line.Split(',').Select(int.Parse).ToArray();
    boxes.Add((split[0], split[1], split[2]));
}

var distances = new List<(double Distance, int From, int To)>(boxes.Count * boxes.Count / 2);
var circuits = new List<HashSet<int>>(boxes.Count);

for (var i = 0; i < boxes.Count; i++)
{
    for (var j = i + 1; j < boxes.Count; j++)
    {
        var x = Math.Pow(boxes[i].X - boxes[j].X, 2);
        var y = Math.Pow(boxes[i].Y - boxes[j].Y, 2);
        var z = Math.Pow(boxes[i].Z - boxes[j].Z, 2);
        var distance = x + y + z;
        distances.Add((distance, i, j));
    }

    circuits.Add([i]);
}

distances = [.. distances.OrderBy(d => d.Distance)];

foreach (var distance in distances.Take(pairs))
{
    var fromCircuit = circuits.First(c => c.Contains(distance.From));
    var toCirciut = circuits.First(c => c.Contains(distance.To));

    if (fromCircuit != toCirciut)
    {
        fromCircuit.UnionWith(toCirciut);
        circuits.Remove(toCirciut);
    }
}

var largestCircuits = circuits.OrderByDescending(c => c.Count).Take(3);
var result = largestCircuits.Aggregate(1, (result, circuit) => result * circuit.Count);

Console.WriteLine($"Result: {result}");
