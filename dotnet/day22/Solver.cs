using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day22
{
    class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; private set; }
        public int Used { get; private set; }
        public int Avail { get { return Size - Used; } }

        public Node(int x, int y, int size, int used)
        {
            X = x;
            Y = y;
            Size = size;
            Used = used;
        }
    }

    public class Solver
    {
        readonly List<string> _instructions;

        public Solver(IEnumerable<string> instructions)
        {
            _instructions = new List<string>(instructions);
        }

        public int HowManyViablePairsOfNodes()
        {
            var nodes = CreateNodesFromInstructions(_instructions).ToList();

            var combos = nodes.Combinations(2);

            var count = 0;
            foreach (var combo in combos)
            {
                if (combo.First().Used > 0 && combo.First().Used <= combo.Last().Avail)
                    count++;

                if (combo.Last().Used > 0 && combo.Last().Used <= combo.First().Avail)
                    count++;
            }
            return count;
        }

        static IEnumerable<Node> CreateNodesFromInstructions(IEnumerable<string> instructions)
        {
            var list = new List<string>(instructions);
            for (int i = 2; i < list.Count; i++)
            {
                var instruction = list[i];
                var coords = instruction.Substring(15, 9).Split('-');
                var x = int.Parse(coords[0].Substring(1));
                var y = int.Parse(coords[1].Substring(1));
                var size = int.Parse(instruction.Substring(25, 5).Replace("T", ""));
                var used = int.Parse(instruction.Substring(31, 5).Replace("T", ""));

                yield return new Node(x, y, size, used);
            }
        }
    }

    static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }
    }
}
