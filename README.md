# AdventOfCode2016

### Day 11
- Unit tests in `dotnet\day11\Day11Tests.cs`
- `Search` class performs a bread-first search to traverse the tree of moves
- `State` class represents the state of the building at a give time, and `Item` instances can be `ItemType.Microchip` and `ItemType.Generator`
- *Note*: part 2 unit test has `Assert.Inconclusive()` so that it will be skipped.  It takes around 5.5 minutes to run through my input.
- See the notes in the unit test for details on the tricky parts
- This one was by far the most difficult, hands down.

### Day 10
- Unit tests in `dotnet\day10\Day10Tests.cs`
- `Bot` and `Output` classes used to model the problem
- Instructions are processed until all bots have 2 chips to get answer

### Day 9 (Part 1 only)
- Unit tests in `dotnet\day9\Day9Tests.cs`
- See `Example1()` through `Example6()` methods for each example
- Part 2 examples working using recursion
- Part2 test throws an `OutOfMemoryException`, so another approach is needed

### Day 8
- Run console app with `8` as input for visualization of instructions
- Unit tests in `dotnet\day8\Day8Tests.cs`
- See `SolverUnitTests()` method for unit tests for the Screen and Solver classes
- I didn't write anything to interpret the screen for part2...run the unit test and the answer will be written to the console.

### Day 7
- Unit tests in `dotnet\day7\Day7Tests.cs`
- See `SolverTests()` method for unit tests on internal methods
- Regex used to determine ABBAs and split protocol parts

### Day 6
- Unit tests in `dotnet\day6\Day6Tests.cs`
- Uses linq to find frequency
- This one was really easy

### Day 5
- Unit tests in `dotnet\day5\Day5Tests.cs`
- Uses standard `System.Security.Cryptography` for MD5
- *Note*: most of the unit tests have an `Assert.Inconclusive()` so they will be skipped.  These solutions require sequential crypto calls, so they take a while to run.

### Day 4
- Unit tests in `dotnet\day4\Day4Tests.cs`
- Regex is used to extract sector id
- Room holds elements of the room

### Day 3
- Unit tests in `dotnet\day3\Day3Tests.cs`

### Day 2
- Unit tests in `dotnet\day2\Day2Tests.cs`
- Solver gets injected with a keyboard layout
- Tuples used to hold buttons and coordinates

### Day 1
- Unit tests in `dotnet\day1\Day1Tests.cs`
- Vectors and Points are used to hold position
- Solver runs all moves then derives answers from move/location history
- Solver calculates distance to start
