using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace dotnet.day25
{
    [TestClass]
    public class Day25Tests
    {

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day25\\input.txt");
            var input = File.ReadAllLines(path);

            var s = new Solver(input);

            Assert.AreEqual(182, s.Solve(0));
        }
    }
}
