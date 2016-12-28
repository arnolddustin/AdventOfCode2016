using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace dotnet.day20
{
    [TestClass]
    public class Day20Tests
    {
        [TestMethod]
        public void Example()
        {
            var s = new Solver(new string[] { "5-8", "0-2", "4-7" });

            Assert.AreEqual(3, s.GetLowestUnblockedIP());
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day20\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input);
            long expected = 19449262;

            var actual = solver.GetLowestUnblockedIP();

            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void Example2()
        //{
        //    var s = new Solver(5);

        //    var result = s.WhichElfGetsAllThePresentsPart2();

        //    Assert.AreEqual(2, result);
        //}

        //[TestMethod]
        //public void Part2()
        //{
        //    var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day19\\input.txt");
        //    var input = File.ReadAllLines(path);

        //    var solver = new Solver(int.Parse(input.First()));
        //    var expected = 1410967;

        //    var actual = solver.WhichElfGetsAllThePresentsPart2();

        //    Assert.AreEqual(expected, actual);
        //}
    }
}
