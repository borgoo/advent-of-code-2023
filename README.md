# advent-of-code-2023
I'm working through these challenges in **2025** as a way to practice TDD principles and improve my C# skills.

## About this project
This project contains my solutions to the Advent of Code 2023 challenges, implemented in C# using a Test-Driven Development (TDD) approach with NUnit testing framework. 

## Approach

- **Test-Driven Development**: Each solution is developed using the red-green-refactor cycle
- **NUnit Testing**: All solutions are thoroughly tested with unit tests
- **C# .NET**: Solutions are implemented in C# using modern .NET features

## Project Structure

```
advent-of-code-2023/
├── docs/                    # Problem documentation for each day
├── src/                     # Source code solutions
└── tests/                   # Unit tests and test data
```

## Data Structures & Algorithms

### Data Structures
- **Trie**: Custom implementation for efficient string pattern matching (Day 1, Day 15)
- **Dictionary**: Used extensively for mapping and caching
- **HashSet**: For unique element tracking and fast lookups
- **List/Array**: For sequential data processing
- **Queue/Stack**: For traversal algorithms
- **PriorityQueue**: For sorting and ranking operations (Day 7)

### Algorithms
- **String Pattern Matching**: Trie-based search for spelled numbers
- **Mathematical Algorithms**: 
  - Greatest Common Divisor (GCD) using Euclidean algorithm
  - Least Common Multiple (LCM) calculation
- **Grid Manipulation**: 90-degree clockwise rotation algorithms
- **Sorting**: Custom comparison logic for poker hands
- **Two-Pointer Technique**: For efficient string processing
- **Graph Traversal**: Various pathfinding and exploration algorithms

## Running Tests

### Prerequisites
- .NET 10.0 SDK
- Visual Studio 2022 or VS Code with C# extension

### Command Line
```bash
# Run all tests from root directory
dotnet test .\tests\UnitTests\AdventOfCode2023.Tests

# Move to test directory
cd .\tests\UnitTests\AdventOfCode2023.Tests

    #Run all tests from here
    dotnet test
    # Run Part1 Tests for Day1 (without rebuilding the project)
    dotnet test --filter "Name~Day1Part1_" --no-build
    # Run Part1 & Part2 Tests for Day1 (without rebuilding the project)
    dotnet test --filter "Name~Day1Part1_|Day1Part2_" --no-build

```