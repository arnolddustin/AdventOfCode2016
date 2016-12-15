using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace dotnet.day10
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        public void Example()
        {
            var s = new Solver();

            var input = new string[] {
                "value 5 goes to bot 2",
                "bot 2 gives low to bot 1 and high to bot 0",
                "value 3 goes to bot 1",
                "bot 1 gives low to output 1 and high to bot 0",
                "bot 0 gives low to output 2 and high to output 0",
                "value 2 goes to bot 2" };

            var expected = 2;
            var actual = s.GetBotThatCompares(5, 2, input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day10\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();
            var expected = 86;

            var actual = solver.GetBotThatCompares(61, 17, input);

            Assert.IsTrue(actual < 144, "144 is too high");
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void Part2()
        //{
        //    var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day8\\input.txt");
        //    var input = File.ReadAllLines(path);

        //    var solver = new Solver(50, 6);
        //    var expected = "aovueakv";

        //    Console.WriteLine(solver.ToString());
        //    var actual = solver.ToString();

        //    Assert.AreEqual(expected, actual);
        //}
    }
}
