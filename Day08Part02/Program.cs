var input = File.ReadAllLines("input");
var boxes = new List<(int X, int Y, int Z)>(input.Length);

foreach (var line in input)
{
    var split = line.Split(',').Select(int.Parse).ToArray();
    boxes.Add((split[0], split[1], split[2]));
}

var distances = new PriorityQueue<(int From, int To), double>(boxes.Count * boxes.Count / 2);
var circuits = new List<HashSet<int>>(boxes.Count);

for (var i = 0; i < boxes.Count; i++)
{
    for (var j = i + 1; j < boxes.Count; j++)
    {
        var x = Math.Pow(boxes[i].X - boxes[j].X, 2);
        var y = Math.Pow(boxes[i].Y - boxes[j].Y, 2);
        var z = Math.Pow(boxes[i].Z - boxes[j].Z, 2);
        distances.Enqueue((i, j), x + y + z);
    }

    circuits.Add([i]);
}

while (distances.TryDequeue(out var distance, out _))
{
    var fromCircuit = circuits.First(c => c.Contains(distance.From));
    var toCirciut = circuits.First(c => c.Contains(distance.To));

    if (fromCircuit != toCirciut)
    {
        fromCircuit.UnionWith(toCirciut);
        circuits.Remove(toCirciut);

        if (circuits.Count == 1)
        {
            var result = (long)boxes[distance.From].X * boxes[distance.To].X;
            Console.WriteLine($"Result: {result}");
            return;
        }
    }
}
