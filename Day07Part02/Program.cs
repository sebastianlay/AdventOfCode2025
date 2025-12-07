var input = File.ReadAllLines("input");
var width = input[0].Length;
var start = input[0].IndexOf('S');
var beams = new long[width];
beams[start] = 1;

for (var i = 2; i < input.Length; i += 2)
{
    var splitter = 0;
    while ((splitter = input[i].IndexOf('^', ++splitter)) >= 0)
    {
        if (beams[splitter] > 0)
        {
            beams[splitter - 1] += beams[splitter];
            beams[splitter + 1] += beams[splitter];
            beams[splitter] = 0;
        }
    }
}

var timelines = beams.Sum();
Console.WriteLine($"Timelines: {timelines}");
