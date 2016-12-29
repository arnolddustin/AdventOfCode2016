using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace dotnet.day23
{
    [TestClass]
    public class Day23Tests
    {

        [TestMethod]
        public void Example()
        {
            var input = new string[] {
                "cpy 2 a",
                "tgl a",
                "tgl a",
                "tgl a",
                "cpy 1 a",
                "dec a",
                "dec a"
            };

            var s = new Solver(input, 0);

            var expected = 3;
            var actual = s.GetValueFromRegister('a');

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day23\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input,7);
            var expected = 10953;

            var actual = solver.GetValueFromRegister('a');

            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void Part2()
        //{
        //    var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day12\\input.txt");
        //    var input = File.ReadAllLines(path);

        //    var solver = new Solver(input, true);
        //    var expected = 9227731;

        //    var actual = solver.GetValueFromRegister('a');

        //    Assert.AreEqual(expected, actual);
        //}
    }
}
