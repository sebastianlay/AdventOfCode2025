var input = File.ReadAllLines("input");
var width = input[0].Length;
var start = input[0].IndexOf('S');
var beams = new bool[width];
beams[start] = true;
var splits = 0;

for (var i = 2; i < input.Length; i += 2)
{
    var splitter = 0;
    while ((splitter = input[i].IndexOf('^', ++splitter)) >= 0)
    {
        if (beams[splitter])
        {
            beams[splitter] = false;
            beams[splitter - 1] = true;
            beams[splitter + 1] = true;
            splits++;
        }
    }
}

Console.WriteLine($"Splits: {splits}");
