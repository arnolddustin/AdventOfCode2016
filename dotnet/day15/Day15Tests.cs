using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace dotnet.day15
{
    [TestClass]
    public class Day15Tests
    {
        [TestMethod]
        public void Examples()
        {
            var s = new Solver(
                    new Disc(5, 4),
                    new Disc(2, 1)
                );

            Assert.AreEqual(5, s.Example());
        }

        [TestMethod]
        public void Part1()
        {
            var solver = new Solver(
                new Disc(31, 11),
                new Disc(5, 0),
                new Disc(17, 11),
                new Disc(3, 0),
                new Disc(7, 2),
                new Disc(19, 17)
                );

            var expected = 122318;
            var actual = solver.Part1();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var solver = new Solver(
                new Disc(31, 11),
                new Disc(5, 0),
                new Disc(17, 11),
                new Disc(3, 0),
                new Disc(7, 2),
                new Disc(19, 17),
                new Disc(11, 0)
                );

            var expected = 3208583;
            var actual = solver.Part2();

            Assert.AreEqual(expected, actual);
        }
    }
}
