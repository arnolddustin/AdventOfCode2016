using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace dotnet.day18
{
    [TestClass]
    public class Day18Tests
    {
        [TestMethod]
        public void u_GetNextRows()
        {
            var s = new Solver("..^^.");

            var nextrows = s.GetNextRows(2).ToList();

            Assert.AreEqual(2, nextrows.Count());
            Assert.AreEqual(".^^^^", nextrows[0]);
            Assert.AreEqual("^^..^", nextrows[1]);

            s = new Solver(".^^.^.^^^^");

            nextrows = s.GetNextRows(9).ToList();
            Assert.AreEqual(9, nextrows.Count());
            Assert.AreEqual("^^..^.^^..", nextrows[4]);
            Assert.AreEqual("^^.^^^..^^", nextrows[8]);
        }

        [TestMethod]
        public void u_GetSafeTileCount()
        {
            var s = new Solver(".^^.^.^^^^");
            Assert.AreEqual(38, s.GetSafeTileCount(9));
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day18\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input.First());
            var expected = 2;

            var actual = solver.GetSafeTileCount(39);

            Assert.AreEqual(expected, actual);
        }
    }
}
