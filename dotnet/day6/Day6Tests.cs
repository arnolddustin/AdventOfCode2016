using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace dotnet.day6
{
    [TestClass]
    public class Day6Tests
    {
        [TestMethod]
        public void Example()
        {
            var solver = new Solver();

            var lines = new List<string>(new string[] { "eedadn",
            "drvtee",
            "eandsr",
            "raavrd",
            "atevrs",
            "tsrnev",
            "sdttsa",
            "rasrtv",
            "nssdts",
            "ntnada",
            "svetve",
            "tesnvt",
            "vntsnd",
            "vrdear",
            "dvrsen",
            "enarar" });

            var expected = "easter";
            var actual = solver.DecodeMessage(lines);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day6\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();
            var expected = "umejzgdw";

            var actual = solver.DecodeMessage(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day6\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();
            var expected = "aovueakv";

            var actual = solver.DecodeMessageReverse(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
