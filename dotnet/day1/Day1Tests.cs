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
            var solver = new Solver();

            var expected = 5;
            var actual = solver.GetShortestPathToDestination("R2, L3");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example2()
        {
            var solver = new Solver();

            var expected = 2;
            var actual = solver.GetShortestPathToDestination("R2, R2, R2");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example3()
        {
            var solver = new Solver();

            var expected = 12;
            var actual = solver.GetShortestPathToDestination("R5, L5, R5, R3");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day1\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();

            var expected = 234;
            var actual = solver.GetShortestPathToDestination(input[0]);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day1\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();

            var expected = 113;
            var actual = solver.GetShortestPathToFirstLocationVisitedTwice(input[0]);

            Assert.AreEqual(expected, actual);
        }
    }
}
