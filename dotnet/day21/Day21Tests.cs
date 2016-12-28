using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace dotnet.day21
{
    [TestClass]
    public class Day21Tests
    {
        [TestMethod]
        public void u_SwapPosition()
        {
            var s = "abcdefgh";

            Assert.AreEqual("abfdecgh", s.SwapPosition(2, 5));
        }

        [TestMethod]
        public void u_SwapLetter()
        {
            var s = "abcdefgh";

            Assert.AreEqual("agcdefbh", s.SwapLetter('b', 'g'));
        }

        [TestMethod]
        public void u_RotateLeft()
        {
            var s = "abcdefgh";

            Assert.AreEqual("cdefghab", s.RotateLeft(2));
        }

        [TestMethod]
        public void u_RotateRight()
        {
            var s = "abcdefgh";

            Assert.AreEqual("fghabcde", s.RotateRight(3));
        }

        [TestMethod]
        public void u_RotateBasedOnLetterPosition()
        {
            var s = "abcdefgh";

            Assert.AreEqual("cdefghab", s.RotateBaseOnLetterPosition('e'));
        }

        [TestMethod]
        public void u_ReversePositions()
        {
            var s = "abcdefgh";

            Assert.AreEqual("abfedcgh", s.ReversePositions(2, 5));
            Assert.AreEqual("edcbafgh", s.ReversePositions(0, 4));
        }

        [TestMethod]
        public void u_MovePosition()
        {
            var s = "abcdefgh";

            Assert.AreEqual("abdefcgh", s.MovePosition(2, 5));
        }

        [TestMethod]
        public void u_Scramble()
        {
            var input = new string[]
            {
                "swap position 4 with position 0",
                "swap letter d with letter b",
                "reverse positions 0 through 4",
                "rotate left 1 step",
                "move position 1 to position 4",
                "move position 3 to position 0",
                "rotate based on position of letter b",
                "rotate based on position of letter d"
            };

            var expected = "decab";
            var s = new Solver("abcde", input);

            Assert.AreEqual(expected, s.GetScrambledPassword());
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day21\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver("abcdefgh", input);
            var expected = "fdhbcgea";

            var actual = solver.GetScrambledPassword();

            Assert.AreEqual(expected, actual);
        }
    }
}
