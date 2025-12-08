var input = File.ReadAllLines("input");
var boxes = new List<(int x, int y, int z)>(input.Length);
const int pairs = 1000;

foreach (var line in input)
{
    var split = line.Split(',').Select(int.Parse).ToArray();
    boxes.Add((split[0], split[1], split[2]));
}

var distances = new List<(double distance, int from, int to)>(boxes.Count * boxes.Count / 2);
var circuits = new List<HashSet<int>>(boxes.Count);

for (var i = 0; i < boxes.Count; i++)
{
    for (var j = i + 1; j < boxes.Count; j++)
    {
        var x = Math.Pow(boxes[i].x - boxes[j].x, 2);
        var y = Math.Pow(boxes[i].y - boxes[j].y, 2);
        var z = Math.Pow(boxes[i].z - boxes[j].z, 2);
        var distance = x + y + z;
        distances.Add((distance, i, j));
    }

    circuits.Add([i]);
}

distances = [.. distances.OrderBy(d => d.distance)];

foreach (var distance in distances.Take(pairs))
{
    var fromCircuit = circuits.First(c => c.Contains(distance.from));
    var toCirciut = circuits.First(c => c.Contains(distance.to));

    if (fromCircuit != toCirciut)
    {
        fromCircuit.UnionWith(toCirciut);
        circuits.Remove(toCirciut);
    }
}

var largestCircuits = circuits.OrderByDescending(c => c.Count).Take(3);
var result = largestCircuits.Aggregate(1, (result, circuit) => result * circuit.Count);

Console.WriteLine($"Result: {result}");
