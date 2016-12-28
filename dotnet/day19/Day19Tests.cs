using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace dotnet.day19
{
    [TestClass]
    public class Day19Tests
    {
        [TestMethod]
        public void Example()
        {
            var s = new Solver(5);

            var result = s.WhichElfGetsAllThePresents();

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day19\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(int.Parse(input.First()));
            var expected = 1816277;

            var actual = solver.WhichElfGetsAllThePresents();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example2()
        {
            var s = new Solver(5);

            var result = s.WhichElfGetsAllThePresentsPart2();

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day19\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(int.Parse(input.First()));
            var expected = 1410967;

            var actual = solver.WhichElfGetsAllThePresentsPart2();

            Assert.AreEqual(expected, actual);
        }
    }
}
