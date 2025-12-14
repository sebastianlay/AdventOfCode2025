# Advent Of Code 2025

My solutions for the [Advent of Code 2025](https://adventofcode.com/2025), using .NET 10 and C# 14.

### A few rules and goals I set for myself:
- All solutions are self-contained, meaning:
    - Each solution has exactly one code file and one project file
    - No external dependencies / NuGet packages
    - No shared libraries or extensions
- Use top-level statements only and reduce file length
    - No namespaces, no explicit main method
    - All code files are less than 100 lines
    - Moving usings to the project files is allowed
    - All while still maintaining a decent level of readability
- Find reasonably efficient algorithms
    - Each solution should complete in less than one second
    - The required memory should be less than 1 GB

### A few things I learned / tried out with this project:
- The [Enumerable.SequenceEqual](https://github.com/sebastianlay/AdventOfCode2025/blob/main/AdventOfCode2025/Day10Part01/Program.cs#L34) method for quickly comparing arrays
- [Record classes](https://github.com/sebastianlay/AdventOfCode2025/blob/main/AdventOfCode2025/Day10Part02/Program.cs#L91-L93) with primary constructors for concise immutable types
- The [PriorityQueue](https://github.com/sebastianlay/AdventOfCode2025/blob/main/AdventOfCode2025/Day08Part02/Program.cs#L10) collection type for an efficient sorted collection
- The [BitOperations.PopCount](https://github.com/sebastianlay/AdventOfCode2025/blob/main/AdventOfCode2025/Day10Part02/Program.cs#L35) method for counting the bits set in an unsigned number
- The new [SLNX solution format](https://github.com/sebastianlay/AdventOfCode2025/blob/main/AdventOfCode2025/AdventOfCode.slnx) with a lot less boilerplate compared to SLN
