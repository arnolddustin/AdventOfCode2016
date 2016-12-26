# AdventOfCode2016

### Day 14
- [Unit tests](dotnet/day14/Day14Tests.cs)
- Only Part 1 completed
- A `Dictionary<int, string>` is used to cache MD5 hashes for the indexes

### Day 13
- [Unit tests](dotnet/day13/Day13Tests.cs)
- `Solver` takes the input in the constructor
- Both parts use a bread-first search to calculate steps/locations
- The `FindMinimumStepsBetween(int, int, int, int)` method finds the minimum steps between two points
- The `LocationsWithinSteps(int, int, int)` method returns a count of all unique locations reachable within the specified steps


### Day 12
- [Unit tests](dotnet/day12/Day12Tests.cs)
- `Solver` takes the input in the constructor (along with flag indicating whether it's part 2 or not)
- The `GetValueFromRegister(char)` method runs the first instruction, then returns the value in the register at the end of the processing chain
- When an instruction is executed, it returns the index of the next instruction

### Day 11
- [Unit tests](dotnet/day11/Day11Tests.cs) 
- Part 1 solves in < 1s, and Part 2 in about 20 seconds
- `Solver` class performs a bread-first search to traverse the tree of moves
- `State` class represents the state of the building at a give time, and `Item` instances can be `ItemType.Microchip` and `ItemType.Generator`
- This one is more difficult than previous days
  * See the notes [in the unit test](dotnet/day11/Day11Tests.cs#L13) for details on how equivalent states are determined 
  * *Spoiler:* The magic to this solution is in how `State` instances are represented during `toString()`

### Day 10
- [Unit tests](dotnet/day10/Day10Tests.cs)
- `Bot` and `Output` classes used to model the problem
- Instructions are processed until all bots have 2 chips to get answer

### Day 9 (Part 1 only)
- [Unit tests](dotnet/day9/Day9Tests.cs)
- See `Example1()` through `Example6()` methods for each example
- Part 2 examples working using recursion
- Part2 test throws an `OutOfMemoryException`, so another approach is needed

### Day 8
- Run console app with `8` as input for visualization of instructions
- [Unit tests](dotnet/day8/Day8Tests.cs)
- See `SolverUnitTests()` method for unit tests for the Screen and Solver classes
- I didn't write anything to interpret the screen for part2...run the unit test and the answer will be written to the console.

### Day 7
- [Unit tests](dotnet/day7/Day7Tests.cs)
- See `SolverTests()` method for unit tests on internal methods
- Regex used to determine ABBAs and split protocol parts

### Day 6
- [Unit tests](dotnet/day6/Day6Tests.cs)
- Uses linq to find frequency
- This one was really easy

### Day 5
- [Unit tests](dotnet/day5/Day5Tests.cs)
- Uses standard `System.Security.Cryptography` for MD5
- *Note*: most of the unit tests have an `Assert.Inconclusive()` so they will be skipped.  These solutions require sequential crypto calls, so they take a while to run.

### Day 4
- [Unit tests](dotnet/day4/Day4Tests.cs)
- Regex is used to extract sector id
- Room holds elements of the room

### Day 3
- [Unit tests](dotnet/day3/Day3Tests.cs)

### Day 2
- [Unit tests](dotnet/day2/Day2Tests.cs)
- Solver gets injected with a keyboard layout
- Tuples used to hold buttons and coordinates

### Day 1
- [Unit tests](dotnet/day1/Day1Tests.cs)
- Vectors and Points are used to hold position
- Solver runs all moves then derives answers from move/location history
- Solver calculates distance to start
