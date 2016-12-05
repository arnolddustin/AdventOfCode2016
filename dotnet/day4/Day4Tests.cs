using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace dotnet.day4
{
    [TestClass]
    public class Day4Tests
    {
        [TestMethod]
        public void Example1()
        {
            var solver = new Solver();

            var expected = 1514;

            var input = new string[] { "aaaaa-bbb-z-y-x-123[abxyz]", "a-b-c-d-e-f-g-h-987[abcde]", "not-a-real-room-404[oarel]", "totally-real-room-200[decoy]" };

            var actual = solver.GetSumOfSectorIdsForRealRooms(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day4\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();
            var expected = 173787;

            var actual = solver.GetSumOfSectorIdsForRealRooms(input);
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void Part2()
        //{
        //    var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day3\\input.txt");
        //    var input = File.ReadAllLines(path);

        //    var solver = new Solver();
        //    var expected = 1826;

        //    var actual = solver.GetValidVerticleTriangleCount(input);
        //    Assert.AreEqual(expected, actual);
        //}
    }
}
