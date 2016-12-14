# AdventOfCode2016

### Day 8
- Unit tests in `dotnet\day8\Day8Tests.cs`
- See `SolverUnitTests()` method for unit tests for the Screen and Solver classes

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
