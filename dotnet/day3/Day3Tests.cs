using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace dotnet.day3
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void Example1()
        {
            var solver = new Solver();

            var expected = 1;
            var input = new string[] { "    5   10   25", "    3    4    5" };

            var actual = solver.GetValidTriangleCount(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day3\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();
            var expected = 982;

            var actual = solver.GetValidTriangleCount(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day3\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();
            var expected = 1826;

            var actual = solver.GetValidVerticleTriangleCount(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
