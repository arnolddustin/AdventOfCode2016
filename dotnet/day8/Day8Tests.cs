using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace dotnet.day8
{
    [TestClass]
    public class Day8Tests
    {
        [TestMethod]
        public void Examples()
        {
            var s = new Solver(7, 3);

            var expected = string.Format(".......{0}.......{0}.......", '\n');
            var actual = s.ToString();
            Assert.AreEqual(expected, actual);

            s.ProcessInstruction("rect 3x2");
            expected = string.Format("###....{0}###....{0}.......", '\n');
            actual = s.ToString();
            Assert.AreEqual(expected, actual, "after first move");

            s.ProcessInstruction("rotate column x=1 by 1");
            expected = string.Format("#.#....{0}###....{0}.#.....", '\n');
            actual = s.ToString();
            Assert.AreEqual(expected, actual, "after rotate column 1x1");

            s.ProcessInstruction("rotate row y=0 by 4");
            expected = string.Format("....#.#{0}###....{0}.#.....", '\n');
            actual = s.ToString();
            Assert.AreEqual(expected, actual, "after rotate row 0x4");

            s.ProcessInstruction("rotate column x=1 by 1");
            expected = string.Format(".#..#.#{0}#.#....{0}.#.....", '\n');
            actual = s.ToString();
            Assert.AreEqual(expected, actual, "after rotate column 1x1");
        }

        [TestMethod]
        public void SolverUnitTests()
        {
            var s = new Screen(7, 3);

            var rotated = s.ShiftRight("ABCDEFG".ToArray());
            Assert.AreEqual("GABCDEF", string.Join("", rotated));

            var expected = string.Format(".......{0}.......{0}.......", '\n');
            var actual = s.ToString();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(0, s.CountLitPixels());

            s.Rect(3, 2);
            expected = string.Format("###....{0}###....{0}.......", '\n');
            actual = s.ToString();
            Assert.AreEqual(expected, actual, "after first move");
            Assert.AreEqual(6, s.CountLitPixels());

            s.RotateColumn(1, 1);
            expected = string.Format("#.#....{0}###....{0}.#.....", '\n');
            actual = s.ToString();
            Assert.AreEqual(expected, actual, "after rotate column 1x1");
            Assert.AreEqual(6, s.CountLitPixels());

            s.RotateRow(0, 4);
            expected = string.Format("....#.#{0}###....{0}.#.....", '\n');
            actual = s.ToString();
            Assert.AreEqual(expected, actual, "after rotate row 0x4");
            Assert.AreEqual(6, s.CountLitPixels());

            s.RotateColumn(1, 1);
            expected = string.Format(".#..#.#{0}#.#....{0}.#.....", '\n');
            actual = s.ToString();
            Assert.AreEqual(expected, actual, "after rotate column 1x1");
            Assert.AreEqual(6, s.CountLitPixels());

            s.Rect(3, 3);
            expected = string.Format("###.#.#{0}###....{0}###....", '\n');
            actual = s.ToString();
            Assert.AreEqual(expected, actual, "after 2nd rect");
            Assert.AreEqual(11, s.CountLitPixels());
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day8\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(50, 6);
            var expected = 123;

            var actual = solver.HowManyPixelsAreLit(input);

            Assert.IsTrue(actual > 68, "too low");
            Assert.IsTrue(actual < 232, "too low");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day8\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(50, 6);
            var expected = "AFBUPZBJPS";

            solver.WriteScreenToConsole(input);

            Assert.Inconclusive("check console for output: " + expected);
        }
    }
}
