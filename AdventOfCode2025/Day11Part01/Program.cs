var input = File.ReadAllLines("input");
var devices = input.ToDictionary(line => line[..3], line => line[5..].Split(' '));
var paths = GetPaths("you");

Console.WriteLine($"Paths: {paths}");
return;

int GetPaths(string name) => name == "out" ? 1 : devices[name].Sum(GetPaths);
