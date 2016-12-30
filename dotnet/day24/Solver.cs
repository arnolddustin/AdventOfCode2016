using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day24
{
    static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }
    }

    public enum Directions { Up, Down, Left, Right }

    public class Target : IEquatable<Target>
    {
        public int Number { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Target(int number, int x, int y)
        {
            Number = number;
            X = x;
            Y = y;
        }

        public bool Equals(Target other)
        {
            return Number == other.Number;
        }

        public override string ToString()
        {
            return string.Format("{0}({1},{2})", Number, X, Y);
        }
    }

    public class State : IEquatable<State>
    {
        readonly List<Target> _targets;

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Depth { get; private set; }

        public State(int x, int y)
        {
            _targets = new List<Target>();
            X = x;
            Y = y;
            Depth = 0;
        }

        State(int x, int y, int depth) : this(x, y)
        {
            Depth = depth;
        }

        public bool Equals(State other)
        {
            return ToString() == other.ToString();
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", X, Y);
        }

        internal IEnumerable<Directions> GetAllowedDirections(IEnumerable<string> map)
        {
            var m = map.ToList();
            var open = "0123456789.".ToArray();

            if (open.Contains(m[Y - 1][X]))
                yield return Directions.Up;

            if (open.Contains(m[Y + 1][X]))
                yield return Directions.Down;

            if (open.Contains(m[Y][X - 1]))
                yield return Directions.Left;

            if (open.Contains(m[Y][X + 1]))
                yield return Directions.Right;
        }

        public IEnumerable<State> GetChildStates(IEnumerable<string> map)
        {
            foreach (var direction in GetAllowedDirections(map))
            {
                switch (direction)
                {
                    case Directions.Up:
                        yield return new State(X, Y - 1, Depth + 1);
                        break;

                    case Directions.Down:
                        yield return new State(X, Y + 1, Depth + 1);
                        break;

                    case Directions.Left:
                        yield return new State(X - 1, Y, Depth + 1);
                        break;

                    case Directions.Right:
                        yield return new State(X + 1, Y, Depth + 1);
                        break;
                }
            }
        }
    }

    public class Segment : IEquatable<Segment>
    {
        public Target Start { get; private set; }
        public Target End { get; private set; }
        public int Length { get; private set; }

        public Segment(Target start, Target end, int length)
        {
            Start = start;
            End = end;
            Length = length;
        }

        public override string ToString()
        {
            return string.Format("{0} => {1} = {2}", Start, End, Length);
        }
        public bool Equals(Segment other)
        {
            return Start == other.Start && End == other.End;
        }
    }

    public class SolutionState : IEquatable<SolutionState>
    {
        public Target Current { get; private set; }
        public int Steps { get; private set; }
        public List<Target> VisitedTargets { get; private set; }

        public SolutionState(Target current)
        {
            Current = current;
            Steps = 0;
            VisitedTargets = new List<Target>();
            VisitedTargets.Add(current);
        }

        SolutionState(Target current, int steps, IEnumerable<Target> visitedTargets) : this(current)
        {
            Steps = steps;

            foreach (var t in visitedTargets)
                if (!VisitedTargets.Contains(t))
                    VisitedTargets.Add(t);
        }

        public bool Equals(SolutionState other)
        {
            if (Current != other.Current) return false;

            if (VisitedTargets.Count != other.VisitedTargets.Count) return false;

            foreach (var t in VisitedTargets)
                if (!other.VisitedTargets.Contains(t))
                    return false;

            return true;
        }

        public override string ToString()
        {
            var vt = string.Join(",", VisitedTargets.Select(t => t.Number.ToString()));
            return string.Format("{0}|{1}", Current, vt);
        }

        public IEnumerable<SolutionState> GetChildStates(IEnumerable<Segment> allSegments)
        {
            foreach (var segment in allSegments.Where(s => s.Start == Current || s.End == Current))
            {
                if (segment.Start == Current)
                    yield return new SolutionState(segment.End, Steps + segment.Length, VisitedTargets);

                if (segment.End == Current)
                    yield return new SolutionState(segment.Start, Steps + segment.Length, VisitedTargets);
            }
        }
    }

    public class Solver
    {
        readonly string[] _map;
        readonly List<Target> _targets;

        public Solver(IEnumerable<string> input)
        {
            _map = input.ToArray();
            _targets = new List<Target>(ExtractTargets(_map));
        }

        public int Solve()
        {
            return FindSolution();
        }

        public int SolveAndComeBack()
        {
            return FindSolution(true);
        }

        int FindSolution(bool andReturn = false)
        {
            var visited = new HashSet<string>();

            var segments = ExtractSegments().ToList();

            int shortestsolution = 999999;
            Target lastVisited = null;
            Target firstVisited = _targets.OrderBy(x => x.Number).First();

            var queue = new Queue<SolutionState>();
            queue.Enqueue(new SolutionState(firstVisited));

            while (queue.Count > 0)
            {
                var parent = queue.Dequeue();

                var children = parent.GetChildStates(segments)
                    .Where(s => !visited.Contains(s.ToString()));

                if (children == null || children.Count() == 0) continue;

                foreach (var child in children)
                {
                    visited.Add(child.ToString());

                    if (child.VisitedTargets.Count == _targets.Count)
                    {
                        if (child.Steps < shortestsolution)
                        {
                            shortestsolution = child.Steps;
                            lastVisited = child.Current;
                        }
                    }
                    else
                        if (child.Steps < shortestsolution)
                        queue.Enqueue(child);
                }
            }

            if (andReturn)
            {
                var segment = segments.FirstOrDefault(s => s.Start == firstVisited && s.End == lastVisited || s.Start == lastVisited && s.End == firstVisited);
                return shortestsolution + segment.Length;
            }
            else
                return shortestsolution;
        }
        internal IEnumerable<Segment> ExtractSegments()
        {
            foreach (var combo in _targets.Combinations(2))
                yield return new Segment(combo.First(), combo.Last(), FindShortestDistanceBetween(combo.First(), combo.Last()));
        }

        internal static IEnumerable<Target> ExtractTargets(string[] map)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < map.Count(); y++)
                {
                    if (map[y].IndexOf(char.Parse(i.ToString())) == -1)
                        continue;

                    yield return new Target(i, map[y].IndexOf(char.Parse(i.ToString())), y);
                }
            }
        }

        internal int FindShortestDistanceBetween(Target t1, Target t2)
        {
            var visited = new HashSet<string>();

            var queue = new Queue<State>();
            queue.Enqueue(new State(t1.X, t1.Y));

            while (queue.Count > 0)
            {
                var parent = queue.Dequeue();

                var children = parent.GetChildStates(_map)
                    .Where(s => !visited.Contains(s.ToString()));

                if (children == null || children.Count() == 0) continue;

                foreach (var child in children)
                {
                    visited.Add(child.ToString());

                    if (child.X == t2.X && child.Y == t2.Y)
                        return child.Depth;
                    else
                        queue.Enqueue(child);
                }
            }

            return -1;
        }
    }
}
