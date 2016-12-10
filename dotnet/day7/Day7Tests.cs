using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace dotnet.day7
{
    [TestClass]
    public class Day7Tests
    {
        [TestMethod]
        public void SolverTests()
        {
            var solver = new Solver();

            // abba tests
            Assert.IsTrue(solver.ContainsABBA("123ghhg34w"), "has abba pattern");
            Assert.IsFalse(solver.ContainsABBA("werasdfmnbx"), "does not have abba pattern");
            Assert.IsFalse(solver.ContainsABBA("werwddddoiuy"), "cannot be 4 of the same");
            Assert.IsTrue(solver.ContainsABBA("sdhfabbajdfkjszzzzgsb"), "has abba pattern");
            Assert.IsTrue(solver.ContainsABBA("szzzzsdhfabbajdfkjgsb"), "has abba pattern");

            var line = "assdisddf[fsdfjtyu]cbsdsjdhj[urhjkhasdff]cvsfnwebn[hjsdjkjadfkl]vbjkbwnm";
            var segments = solver.GetSegments(line, true);
            Assert.AreEqual(3, segments.Count());
            segments = solver.GetSegments(line, false);
            Assert.AreEqual(4, segments.Count());

            Assert.IsTrue(solver.SupportsProtocol("abba[mnop]qrst"));
            Assert.IsFalse(solver.SupportsProtocol("abcd[bddb]xyyx"), "has abba in a bracket");
            Assert.IsFalse(solver.SupportsProtocol("aaaa[qwer]tyui"));
            Assert.IsTrue(solver.SupportsProtocol("ioxxoj[asdfgh]zxcvbn"), "has abba inside longer segment");

            var lines = new string[] { "abba[mnop]qrst", "abcd[bddb]xyyx", "aaaa[qwer]tyui", "ioxxoj[asdfgh]zxcvbn" };
            Assert.AreEqual(2, solver.LinesThatSupportProtocol(lines));
        }

        [TestMethod]
        public void Part1()
        {
            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day7\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver();
            var expected = 105;

            var actual = solver.LinesThatSupportProtocol(input);

            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void Part2()
        //{
        //    var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day6\\input.txt");
        //    var input = File.ReadAllLines(path);

        //    var solver = new Solver();
        //    var expected = "aovueakv";

        //    var actual = solver.DecodeMessageReverse(input);

        //    Assert.AreEqual(expected, actual);
        //}
    }
}
