using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace dotnet.day5
{
    [TestClass]
    public class Day4Tests
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
            var solver = new Solver();

            var startingIndex = 3231928;
            var expected = "18F";

            var input = new string[] { "abc" };

            var actual = solver.GetDoorPassword(startingIndex, input[0], 3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example1()
        {
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
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day5\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();
            var expected = "A";

            var actual = solver.GetDoorPassword(0, input[0], 8);

            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void Example2()
        //{
        //    var solver = new Solver();

        //    var expected = "very encrypted name";

        //    var encryptedname = "qzmt-zixmtkozy-ivhz";
        //    var sectorid = 343;

        //    var actual = solver.DecipherName(encryptedname,sectorid);
        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void Part2()
        //{
        //    var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day4\\input.txt");
        //    var input = File.ReadAllLines(path);

        //    var solver = new Solver();
        //    var expected = 548;

        //    var actual = solver.GetSectorIdOfRoomWithNorthPoleObjects(input);
        //    Assert.AreEqual(expected, actual);
        //}
    }
}
