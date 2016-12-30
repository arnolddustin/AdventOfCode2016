# AdventOfCode2016

### Day 24
- [Unit tests](dotnet/day24/Day24Tests.cs)
- Examples, Part 1, and Part 2 complete
- Part 1 approach:
  - Use breadth-first search to find shortest routes between all targets
  - Use breadth-first search to find shortest path along those routes inclusive of all targets
- Part 2 uses Part 1, then adds the length of the shortest path back home

### Day 23
- [Unit tests](dotnet/day22/Day22Tests.cs)
- Examples, Part 1, and Part 2 complete
- Used and adapted Day12 solution to solve part 1
- Part 2 [short-circuits a series of instructions](dotnet/day23/Solver.cs#L62) reduce processing time to ~6ms

### Day 22
- [Unit tests](dotnet/day22/Day22Tests.cs)
- Examples and Part 1 complete

### Day 21
- [Unit tests](dotnet/day21/Day21Tests.cs) for each operation and combined operations
- Examples and Part 1 complete

### Day 20
- [Unit tests](dotnet/day20/Day20Tests.cs)
- Examples, Part 1, and Part 2 solved
- Important parts of the solution
  - [The MergeRanges method](dotnet/day20/Solver.cs#L88) sorts and merges ranges using a `Stack<Range>`
  - [The GetAllowedIps method](dotnet/day20/Solver.cs#L57) builds the list of IPs using the `Stack<Range>`

### Day 19
- [Unit tests](dotnet/day19/Day19Tests.cs)
- Examples, Part 1, and Part2 solved
- Part 1 solution is done using a queue
- Part 2 solution uses math

### Day 18
- [Unit tests](dotnet/day18/Day18Tests.cs) for `GetNextRows()` and `GetSafeTileCount()` methods
- Examples, Part 1, and Part 2 solved

### Day 17
- [Unit tests](dotnet/day17/Day17Tests.cs) for has generation, allowed directions, shortest, and longest path
- Examples, Part 1, and Part 2 solved
- Breadth-first search used to determine shortest and longest paths

### Day 16
- [Unit tests](dotnet/day16/Day16Tests.cs) for dragon curve, checksum, and combined
- Examples, Part 1, and Part 2 solved

### Day 15
- [Unit tests](dotnet/day15/Day15Tests.cs)
- Example, Part 1, and Part 2 solved
- The key algorithm is [in the Disc class](dotnet/day15/Solver.cs#L25)

### Day 14
- [Unit tests](dotnet/day14/Day14Tests.cs)
- Test in part 2 are short-circuited by an `Assert.Inconclusive()` because they take a while (~5 minutes) to run
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
