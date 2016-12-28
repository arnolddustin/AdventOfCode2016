using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace dotnet.day17
{
    [TestClass]
    public class Day17Tests
    {
        [TestMethod]
        public void u_GenerateHash()
        {
            var password = "hijkl";

            var s = new State(0, 0, string.Empty);
            Assert.AreEqual("ced9", s.GenerateHash(password));

            s = new State(0, 1, "D");
            var h = s.GenerateHash(password);
            Assert.AreEqual("f2bc", h);

            s = new State(1, 1, "DR");
            h = s.GenerateHash(password);
            Assert.AreEqual("5745", h);
        }

        [TestMethod]
        public void u_GetAllowedDirections()
        {
            var s = new State(0, 0, string.Empty);

            var password = "hijkl";

            var directions = s.GetAllowedDirections(password);
            Assert.IsTrue(directions.Count() == 1);
            Assert.IsTrue(directions.Single() == Directions.Down);

            s = new State(0, 1, "D");
            var d = s.GetAllowedDirections(password);
            Assert.AreEqual(2, d.Count());
            Assert.IsTrue(d.Contains(Directions.Up));
            Assert.IsTrue(d.Contains(Directions.Right));

            s = new State(1, 1, "DR");
            d = s.GetAllowedDirections(password);
            Assert.AreEqual(0, d.Count());
        }

        [TestMethod]
        public void u_GetShortestPath()
        {
            var s = new Solver("ihgpwlah");
            var actual = s.FindShortestPathTo(3, 3);
            Assert.AreEqual(actual, "DDRRRD");

            s = new Solver("kglvqrro");
            actual = s.FindShortestPathTo(3, 3);
            Assert.AreEqual(actual, "DDUDRLRRUDRD");

            s = new Solver("ulqzkmiv");
            actual = s.FindShortestPathTo(3, 3);
            Assert.AreEqual(actual, "DRURDRUDDLLDLUURRDULRLDUUDDDRR");
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day17\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input.First());
            var expected = "DDRUDLRRRD";

            var actual = solver.FindShortestPathTo(3, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void u_GetLongestPath()
        {
            var s = new Solver("ihgpwlah");
            var actual = s.FindLongestPathStepsTo(3, 3);
            Assert.AreEqual(370, actual);

            s = new Solver("kglvqrro");
            actual = s.FindLongestPathStepsTo(3, 3);
            Assert.AreEqual(492, actual);

            s = new Solver("ulqzkmiv");
            actual = s.FindLongestPathStepsTo(3, 3);
            Assert.AreEqual(830, actual);
        }

        [TestMethod]
        public void Part2()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day17\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(input.First());
            var expected = 398;

            var actual = solver.FindLongestPathStepsTo(3, 3);

            Assert.AreEqual(expected, actual);
        }
    }
}
