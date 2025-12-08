var input = File.ReadAllLines("input");
var boxes = new List<(int x, int y, int z)>(input.Length);

foreach (var line in input)
{
    var split = line.Split(',').Select(int.Parse).ToArray();
    boxes.Add((split[0], split[1], split[2]));
}

var distances = new PriorityQueue<(int from, int to), double>(boxes.Count * boxes.Count / 2);
var circuits = new List<HashSet<int>>(boxes.Count);

for (var i = 0; i < boxes.Count; i++)
{
    for (var j = i + 1; j < boxes.Count; j++)
    {
        var x = Math.Pow(boxes[i].x - boxes[j].x, 2);
        var y = Math.Pow(boxes[i].y - boxes[j].y, 2);
        var z = Math.Pow(boxes[i].z - boxes[j].z, 2);
        distances.Enqueue((i, j), x + y + z);
    }

    circuits.Add([i]);
}

while (distances.TryDequeue(out var distance, out var _))
{
    var fromCircuit = circuits.First(c => c.Contains(distance.from));
    var toCirciut = circuits.First(c => c.Contains(distance.to));

    if (fromCircuit != toCirciut)
    {
        fromCircuit.UnionWith(toCirciut);
        circuits.Remove(toCirciut);

        if (circuits.Count == 1)
        {
            var result = (long)boxes[distance.from].x * boxes[distance.to].x;
            Console.WriteLine($"Result: {result}");
            return;
        }
    }
}
