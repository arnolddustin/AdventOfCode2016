using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace dotnet.day2
{
    [TestClass]
    public class Day2Tests
    {
        [TestMethod]
        public void Example1()
        {
            var solver = new Solver(new NormalKeypadLayout());

            var expected = "1985";
            var input = new string[] { "ULL", "RRDDD", "LURDL", "UUUD" };

            var actual = solver.GetCodeFromInput(input, "5");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day2\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(new NormalKeypadLayout());
            var expected = "92435";

            var actual = solver.GetCodeFromInput(input, "5");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day2\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(new AdvancedKeypadLayout());
            var expected = "C1A88";

            var actual = solver.GetCodeFromInput(input, "5");
            Assert.AreEqual(expected, actual);
        }
    }
}
