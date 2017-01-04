﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day22
{
    public class Node
    {
        public int X;
        public int Y;
        public int Size;
        public int Used;
        public int Avail { get { return Size - Used; } }
        public bool Empty { get { return Used == 0; } }

        public Node(int x, int y, int size, int used)
        {
            X = x;
            Y = y;
            Size = size;
            Used = used;
        }

        public override string ToString()
        {
            return (Empty) ? "." : "_";
        }
    }

    public class State : IEquatable<State>
    {
        public List<State> History;

        public int Depth;
        public List<Node> Nodes;
        public int SpecialX;
        public int SpecialY;

        public State(IEnumerable<Node> nodes, int specialX, int specialY)
        {
            Nodes = new List<Node>(nodes);
            Depth = 0;
            SpecialX = specialX;
            SpecialY = specialY;
            History = new List<State>();
        }

        private State(State parent, Node copyDataFrom, Node copyDataTo)
        {
            Nodes = new List<Node>();
            Depth = parent.Depth + 1;
            History = new List<State>(parent.History);
            History.Add(parent);

            if (copyDataFrom.X == parent.SpecialX && copyDataFrom.Y == parent.SpecialY)
            {
                SpecialX = copyDataTo.X;
                SpecialY = copyDataTo.Y;
            }
            else
            {
                SpecialX = parent.SpecialX;
                SpecialY = parent.SpecialY;
            }

            foreach (var node in parent.Nodes)
            {
                if (node.X == copyDataFrom.X && node.Y == copyDataFrom.Y)
                {
                    Nodes.Add(new Node(node.X, node.Y, copyDataFrom.Size, 0));
                    continue;
                }

                if (node.X == copyDataTo.X && node.Y == copyDataTo.Y)
                {
                    Nodes.Add(new Node(node.X, node.Y, copyDataTo.Size, copyDataTo.Used + copyDataFrom.Used));
                    continue;
                }

                Nodes.Add(node);
            }
        }

        public bool Equals(State other)
        {
            return ToString() == other.ToString();
        }

        public override string ToString()
        {
            //return string.Format("{0}-({1},{2})=>{3}", Depth, SpecialX, SpecialY, string.Join("", Nodes.AsEnumerable()));
            //return string.Format("{0}-{1}", SpecialX, SpecialY);
            var empty = Nodes.Single(n => n.Empty);
            return string.Format("{0}-{1}-{2}-{3}", SpecialX, SpecialY, empty.X, empty.Y);
        }

        public IEnumerable<State> GetChildren()
        {
            foreach (var pair in Nodes.GetAdjacentViablePairs())
                yield return new State(this, pair.Item1, pair.Item2);
        }

        public string Display()
        {
            var xMax = Nodes.Max(n => n.X);
            var yMax = Nodes.Max(n => n.Y);

            var sb = new StringBuilder();
            sb.Append("=====\n   ");

            for (int x = 0; x < xMax + 1; x++)
            {
                if (x < 10)
                    sb.AppendFormat(" {0} ", x);
                else
                    sb.AppendFormat(" {0}", x);
            }
            sb.AppendLine();

            for (int y = 0; y < yMax + 1; y++)
            {
                if (y < 10)
                    sb.AppendFormat("{0}  ", y);
                else
                    sb.AppendFormat("{0} ", y);

                for (int x = 0; x < xMax + 1; x++)
                {
                    var node = Nodes.FirstOrDefault(n => n.X == x && n.Y == y);

                    if (node == null)
                    {
                        sb.Append(" # ");
                    }
                    else if (node.Empty)
                    {
                        sb.Append(" - ");
                    }
                    else
                    {
                        if (node.X == SpecialX && node.Y == SpecialY)
                            sb.Append(" G ");
                        else
                            sb.Append(" . ");
                    }
                }

                sb.AppendLine("");
            }

            return sb.ToString();
        }
    }

    public class Solver
    {
        readonly HashSet<Node> _nodes;

        public Solver(IEnumerable<string> instructions)
        {
            _nodes = new HashSet<Node>(CreateNodesFromInstructions(instructions));
        }

        public int HowManyViablePairsOfNodes()
        {
            return _nodes.GetViablePairs().Count();
        }

        public int FewestStepsToMoveData()
        {
            var nodes = _nodes.Where(n => n.Size < 300).ToList();
            var xMax = nodes.Max(n => n.X);

            var initialState = new State(nodes, xMax, 0);
           
            var steps = GetStepsToEmptyGoal(initialState);

            return steps + ((xMax - 1) * 5);
        }

        static int GetStepsToEmptyGoal(State initialState)
        {
            var xMax = initialState.Nodes.Max(n => n.X);

            var visited = new HashSet<string>();

            var queue = new Queue<State>();
            queue.Enqueue(initialState);

            int iteration = 0;
            while (queue.Count > 0)
            {
                iteration++;

                var parent = queue.Dequeue();

                var children = parent.GetChildren()
                    .Where(s => !visited.Contains(s.ToString()));

                if (children == null || children.Count() == 0) continue;

                foreach (var child in children)
                {
                    if (child.Nodes.Single(n => n.X == xMax && n.Y == 0).Empty)
                        return child.Depth;

                    visited.Add(child.ToString());
                    queue.Enqueue(child);
                }

            }

            return -1;
        }

        static IEnumerable<Node> CreateNodesFromInstructions(IEnumerable<string> instructions)
        {
            var list = new List<string>(instructions);
            for (int i = 2; i < list.Count; i++)
            {
                var instruction = list[i];
                var coords = instruction.Substring(16, 7).Split('-');
                var x = int.Parse(coords[0]);
                var y = int.Parse(coords[1].Substring(1));
                var size = int.Parse(instruction.Substring(24, 3));
                var used = int.Parse(instruction.Substring(30, 3));

                yield return new Node(x, y, size, used);
            }
        }
    }

    static class Extensions
    {
        public static bool IsAdjacentTo(this Node node, Node otherNode)
        {
            return (node.X == otherNode.X && node.Y != otherNode.Y && node.Y > otherNode.Y - 2 && node.Y < otherNode.Y + 2)
                || (node.Y == otherNode.Y && node.X != otherNode.X && node.X > otherNode.X - 2 && node.X < otherNode.X + 2);
        }

        public static IEnumerable<Tuple<Node, Node>> GetAdjacentViablePairs(this IEnumerable<Node> nodes)
        {
            foreach (var node in nodes)
            {
                foreach (var node2 in nodes.Where(n => n.IsAdjacentTo(node)))
                {
                    if (!node.Empty && node.Used <= node2.Avail)
                        yield return new Tuple<Node, Node>(node, node2);

                    if (!node2.Empty && node2.Used <= node.Avail)
                        yield return new Tuple<Node, Node>(node2, node);
                }
            }
        }

        public static IEnumerable<Tuple<Node, Node>> GetViablePairs(this IEnumerable<Node> nodes)
        {
            foreach (var combo in nodes.Combinations(2))
            {
                if (!combo.First().Empty && combo.First().Used <= combo.Last().Avail)
                    yield return new Tuple<Node, Node>(combo.First(), combo.Last());

                if (!combo.Last().Empty && combo.Last().Used <= combo.First().Avail)
                    yield return new Tuple<Node, Node>(combo.Last(), combo.First());
            }
        }

        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }
    }
}
