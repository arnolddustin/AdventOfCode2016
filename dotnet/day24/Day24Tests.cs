using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace dotnet.day24
{
    [TestClass]
    public class Day24Tests
    {
        string[] _sampleMap = new string[]
          {
                "###########",
                "#0.1.....2#",
                "#.#######.#",
                "#4.......3#",
                "###########"
          };


        [TestMethod]
        public void u_ExtractTargets()
        {
            var result = Solver.ExtractTargets(_sampleMap);

            Assert.AreEqual(5, result.Count());
        }

        [TestMethod]
        public void u_FindShortestDistanceBetween()
        {
            var t = Solver.ExtractTargets(_sampleMap).OrderBy(x => x.Number).ToList();

            var s = new Solver(_sampleMap);

            Assert.AreEqual(2, s.FindShortestDistanceBetween(t[0], t[1]));
            Assert.AreEqual(2, s.FindShortestDistanceBetween(t[0], t[4]));
            Assert.AreEqual(8, s.FindShortestDistanceBetween(t[1], t[3]));
            Assert.AreEqual(10, s.FindShortestDistanceBetween(t[0], t[3]));
        }

        [TestMethod]
        public void Example()
        {
            var s = new Solver(_sampleMap);

            Assert.AreEqual(14, s.Solve());
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day24\\input.txt");
            var input = File.ReadAllLines(path);

            var s = new Solver(input);

            var actual = s.Solve();
            Assert.AreEqual(470, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day24\\input.txt");
            var input = File.ReadAllLines(path);

            var s = new Solver(input);

            var actual = s.SolveAndComeBack();
            Assert.AreEqual(470, actual);
        }
    }
}
