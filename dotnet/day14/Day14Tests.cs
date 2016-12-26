using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace dotnet.day14
{
    [TestClass]
    public class Day14Tests
    {
        [TestMethod]
        public void Examples()
        {
            var s = new Solver("abc");

            var indexes = s.GetIndexes(64).ToList();
            Assert.IsTrue(indexes.Count() > 0);

            var first = indexes.First();
            Assert.AreEqual(39, first);

            var last = indexes.Last();
            Assert.AreEqual(22728, last);
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day14\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input.First());
            var expected = 96;

            var actual = solver.GetIndexes(64).Last();

            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void Part2()
        //{
        //    var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day13\\input.txt");
        //    var input = File.ReadAllLines(path);

        //    var solver = new Solver(input.First());
        //    var expected = 141;

        //    var actual = solver.LocationsWithinSteps(1, 1, 50);

        //    Assert.AreEqual(expected, actual);
        //}
    }
}
