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
            var expected = 25427;

            var actual = solver.GetIndexes(64).Last();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExamplesPart2()
        {
            Assert.Inconclusive("this test takes >5 minutes to run");
            var s = new Solver("abc");

            //var expected = "a107ff634856bb300138cac6568c0f24";
            //Assert.AreEqual(expected, s.GetStretchedIndexes(64).Last());

            Assert.AreEqual(22551, s.GetStretchedIndexes(64).Last());
        }

        [TestMethod]
        public void Part2()
        {
            Assert.Inconclusive("this test takes >5 minutes to run");
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day14\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input.First());
            var expected = 22045;

            var actual = solver.GetStretchedIndexes(64).Last();

            Assert.AreEqual(expected, actual);
        }
    }
}
