using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace dotnet.day13
{
    [TestClass]
    public class Day13Tests
    {
        [TestMethod]
        public void Solver_IsWall()
        {
            var solver = new Solver("10");

            Assert.IsFalse(solver.IsWall(0, 0));
            Assert.IsTrue(solver.IsWall(1, 0));
            Assert.IsFalse(solver.IsWall(2, 0));
            Assert.IsTrue(solver.IsWall(4, 3));
            Assert.IsFalse(solver.IsWall(6, 6));
            Assert.IsTrue(solver.IsWall(7, 6));
        }

        [TestMethod]
        public void Solver_ShortestPath()
        {
            var solver = new Solver("10");

            var expected = 11;
            var actual = solver.FindMinimumStepsBetween(1, 1, 7, 4);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day13\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input.First());
            var expected = 96;

            var actual = solver.FindMinimumStepsBetween(1, 1, 31, 39);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day13\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input.First());
            var expected = 141;

            var actual = solver.LocationsWithinSteps(1, 1, 50);

            Assert.AreEqual(expected, actual);
        }
    }
}
