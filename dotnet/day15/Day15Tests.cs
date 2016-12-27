using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace dotnet.day15
{
    [TestClass]
    public class Day15Tests
    {
        [TestMethod]
        public void Examples()
        {
            var s = new Solver();
            var discs = new Disc[] {
                new Disc(1, 5, 4),
                new Disc(2, 2, 1)
            };

            Assert.AreEqual(5, s.Solve(discs));

        }

        [TestMethod]
        public void Part1()
        {

            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day15\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();

            var expected = 122318;
            var actual = solver.Solve(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day15\\input.txt");
            var input = File.ReadAllLines(path);

            var list = new List<string>(input);
            list.Add("Disc #7 has 11 positions; at time=0, it is at position 0.");

            var solver = new Solver();

            var expected = 3208583;
            var actual = solver.Solve(list);

            Assert.AreEqual(expected, actual);
        }
    }
}
