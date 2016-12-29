using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace dotnet.day22
{
    [TestClass]
    public class Day22Tests
    {
        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day22\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input);
            var expected = 1024;

            var actual = solver.HowManyViablePairsOfNodes();

            Assert.AreEqual(expected, actual);
        }
    }
}
