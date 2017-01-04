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

        [TestMethod]
        public void Part2_Example()
        {
            var input = new string[]
            {
                "root@ebhq-gridcenter# df -h",
                "Filesystem              Size  Used  Avail  Use%",
                "/dev/grid/node-x0-y0     10T    8T     2T   80%",
                "/dev/grid/node-x0-y1     11T    6T     5T   54%",
                "/dev/grid/node-x0-y2     32T   28T     4T   87%",
                "/dev/grid/node-x1-y0      9T    7T     2T   77%",
                "/dev/grid/node-x1-y1      8T    0T     8T    0%",
                "/dev/grid/node-x1-y2     11T    7T     4T   63%",
                "/dev/grid/node-x2-y0     10T    6T     4T   60%",
                "/dev/grid/node-x2-y1      9T    8T     1T   88%",
                "/dev/grid/node-x2-y2      9T    6T     3T   66%"
            };

            var s = new Solver(input);

            Assert.AreEqual(7, s.FewestStepsToMoveData());
        }

        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day22\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input);
            var expected = 230;

            var actual = solver.FewestStepsToMoveData();

            Assert.AreEqual(expected, actual);
        }
    }
}
