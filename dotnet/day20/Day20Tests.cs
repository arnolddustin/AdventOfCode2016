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

        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day20\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input);
            long expected = 119;

            var actual = solver.GetAllowedIpCount();

            Assert.IsTrue(actual < 923945885, "answer is lower than " + actual.ToString());
            Assert.AreEqual(expected, actual);
        }
    }
}
