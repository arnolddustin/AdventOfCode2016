using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace dotnet.day12
{
    [TestClass]
    public class Day12Tests
    {

        [TestMethod]
        public void Example()
        {
            var input = new string[] {
                "cpy 41 a",
                "inc a",
                "inc a",
                "dec a",
                "jnz a 2",
                "dec a"
            };

            var s = new Solver(input, false);

            var expected = 42;
            var actual = s.GetValueFromRegister('a');

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day12\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input, false);
            var expected = 318077;

            var actual = solver.GetValueFromRegister('a');

            Assert.IsTrue(actual > 317825, "317825 is too low");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day12\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input, true);
            var expected = 9227731;

            var actual = solver.GetValueFromRegister('a');

            Assert.AreEqual(expected, actual);
        }
    }
}
