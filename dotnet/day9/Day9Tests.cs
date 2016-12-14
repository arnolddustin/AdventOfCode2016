using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace dotnet.day9
{
    [TestClass]
    public class Day9Tests
    {
        [TestMethod]
        public void Example1()
        {
            var s = new Solver();

            Assert.AreEqual(6, s.GetDecompressedLength("ADVENT"));
            Assert.AreEqual("ADVENT", s.DecompressString("ADVENT"));
        }
        [TestMethod]
        public void Example2()
        {
            var s = new Solver();

            Assert.AreEqual(7, s.GetDecompressedLength("A(1x5)BC"));
            Assert.AreEqual("ABBBBBC", s.DecompressString("A(1x5)BC"));
        }

        [TestMethod]
        public void Example3()
        {
            var s = new Solver();

            Assert.AreEqual(9, s.GetDecompressedLength("(3x3)XYZ"));
            Assert.AreEqual("XYZXYZXYZ", s.DecompressString("(3x3)XYZ"));
        }

        [TestMethod]
        public void Example4()
        {
            var s = new Solver();

            Assert.AreEqual(11, s.GetDecompressedLength("A(2x2)BCD(2x2)EFG"));
            Assert.AreEqual("ABCBCDEFEFG", s.DecompressString("A(2x2)BCD(2x2)EFG"));
        }

        [TestMethod]
        public void Example5()
        {
            var s = new Solver();

            Assert.AreEqual(6, s.GetDecompressedLength("(6x1)(1x3)A"));
            Assert.AreEqual("(1x3)A", s.DecompressString("(6x1)(1x3)A"));
        }

        [TestMethod]
        public void Example6()
        {
            var s = new Solver();

            Assert.AreEqual(18, s.GetDecompressedLength("X(8x2)(3x3)ABCY"));
            Assert.AreEqual("X(3x3)ABC(3x3)ABCY", s.DecompressString("X(8x2)(3x3)ABCY"));
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day9\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();
            var expected = 152851;

            var actual = solver.GetDecompressedLength(input[0]);

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
