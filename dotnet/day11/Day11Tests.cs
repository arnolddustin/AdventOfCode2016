using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace dotnet.day11
{
    [TestClass]
    public class Day11Tests
    {
        [TestMethod]
        public void Example()
        {
            var s = new Solver();

            var input = new string[] {
                "The first floor contains a promethium generator and a promethium-compatible microchip.",
                "The second floor contains a cobalt generator, a curium generator, a ruthenium generator, and a plutonium generator.",
                "The third floor contains a cobalt-compatible microchip, a curium-compatible microchip, a ruthenium-compatible microchip, and a plutonium-compatible microchip.",
                "The fourth floor contains nothing relevant."
            };

            var expected = 11;
            var actual = s.Example(); //.GetMinimumMoves(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day11\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();
            var expected = 5;

            var actual = 3; // solver.GetMinimumMoves(input);

            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void Part2()
        //{
        //    var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day10\\input.txt");
        //    var input = File.ReadAllLines(path);

        //    var solver = new Solver();
        //    var expected = 22847;

        //    var actual = solver.MultiplyOutputNumbers(input, 0, 1, 2);

        //    Assert.IsTrue(actual > 20167, "20167 is too low");
        //    Assert.AreEqual(expected, actual);
        //}
    }
}
