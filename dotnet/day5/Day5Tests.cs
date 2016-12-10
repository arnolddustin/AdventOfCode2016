using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace dotnet.day5
{
    [TestClass]
    public class Day5Tests
    {
        [TestMethod]
        public void ExamplePart1()
        {
            var solver = new Solver();

            var expected = 3231929;
            var actual = solver.GetFirstHashStartingWithFiveZeroes("abc", 3231928);

            Assert.AreEqual(expected, actual.Item1);

            expected = 5017308;
            actual = solver.GetFirstHashStartingWithFiveZeroes("abc", 5017300);

            Assert.AreEqual(expected, actual.Item1);

            expected = 5278568;
            actual = solver.GetFirstHashStartingWithFiveZeroes("abc", 5278560);

            Assert.AreEqual(expected, actual.Item1);
        }
        [TestMethod]
        public void ExamplePart2()
        {
            Assert.Inconclusive("skipped...takes 14s to run");

            var solver = new Solver();

            var startingIndex = 3231928;
            var expected = "18F";

            var input = new string[] { "abc" };

            var actual = solver.GetDoorPassword(startingIndex, input[0], 3);

            Assert.AreEqual(expected, actual);
        }

        [TestCategory("long running")]
        [TestMethod]
        public void Example1()
        {
            Assert.Inconclusive("skipped...takes 37s to run");

            var solver = new Solver();

            var startingIndex = 3231928;
            var expected = "18F47A30";

            var input = new string[] { "abc" };

            var actual = solver.GetDoorPassword(startingIndex, input[0], 8);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            Assert.Inconclusive("skipped...takes 1 min to run");

            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day5\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();
            var expected = "d4cd2ee1";

            var actual = solver.GetDoorPassword(0, input[0], 8).ToLower();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2_Example()
        {
            Assert.Inconclusive("skipped...takes > 1 min to run");
            var solver = new Solver();

            var expected = "05ace8e3";
            var actual = solver.GetDoorAdvancedPassword(3231929, "abc").ToLower();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            Assert.Inconclusive("skipped...takes 2 min to run");

            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day5\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();
            var expected = "f2c730e5";

            var actual = solver.GetDoorAdvancedPassword(0, input[0]).ToLower();

            Assert.AreEqual(expected, actual);
        }
    }
}
