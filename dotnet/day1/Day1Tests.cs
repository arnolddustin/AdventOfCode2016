using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace dotnet.day1
{
    [TestClass]
    public class Day1Tests
    {
        [TestMethod]
        public void Example1()
        {
            var solver = new Solver("R2, L3");

            var expected = 5;
            var actual = solver.GetShortestPathToDestination();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example2()
        {
            var solver = new Solver("R2, R2, R2");

            var expected = 2;
            var actual = solver.GetShortestPathToDestination();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example3()
        {
            var solver = new Solver("R5, L5, R5, R3");

            var expected = 12;
            var actual = solver.GetShortestPathToDestination();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day1\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input[0]);

            var expected = 234;
            var actual = solver.GetShortestPathToDestination();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day1\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input[0]);

            var expected = 113;
            var actual = solver.GetShortestPathToFirstLocationVisitedTwice();

            Assert.AreEqual(expected, actual);
        }
    }
}
