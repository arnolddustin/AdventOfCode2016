using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace dotnet.day16
{
    [TestClass]
    public class Day16Tests
    {
        [TestMethod]
        public void unit_DragonCurve()
        {
            Assert.AreEqual("100", Solver.DragonCurveSegment("1"));
            Assert.AreEqual("001", Solver.DragonCurveSegment("0"));
            Assert.AreEqual("11111000000", Solver.DragonCurveSegment("11111"));
            Assert.AreEqual("1111000010100101011110000", Solver.DragonCurveSegment("111100001010"));
        }
        [TestMethod]
        public void unit_Checksum()
        {
            Assert.AreEqual("100", Solver.Checksum("110010110100"));
        }

        [TestMethod]
        public void unit_Combined()
        {
            Assert.AreEqual("01100", Solver.Solve("10000", 20));
        }

        [TestMethod]
        public void Part1()
        {

            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day16\\input.txt");
            var input = File.ReadAllLines(path);

            var expected = "10100101010101101";
            var actual = Solver.Solve(input.First(), 272);

            Console.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day16\\input.txt");
            var input = File.ReadAllLines(path);

            var expected = "01100001101101001";
            var actual = Solver.Solve(input.First(), 35651584);

            Console.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
