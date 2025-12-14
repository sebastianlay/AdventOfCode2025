var input = File.ReadAllLines("input");
var devices = input.ToDictionary(line => line[..3], line => line[5..].Split(' '));
var cache = new ConcurrentDictionary<(string name, bool dac, bool fft), long>();
var paths = GetPaths("svr", false, false);

Console.WriteLine($"Paths: {paths}");
return;

long GetPaths(string name, bool dac, bool fft)
{
    if (name == "dac") dac = true;
    if (name == "fft") fft = true;
    if (name == "out") return dac && fft ? 1 : 0;

    return cache.GetOrAdd((name, dac, fft), _ => devices[name].Sum(o => GetPaths(o, dac, fft)));
}
