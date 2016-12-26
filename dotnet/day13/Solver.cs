using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day13
{
    public class State : IEquatable<State>
    {
        public int Depth { get; private set; }

        public int X { get; private set; }
        public int Y { get; private set; }

        public State(int x, int y)
        {
            Depth = 0;
            X = x;
            Y = y;
        }

        State(int x, int y, int depth) : this(x, y)
        {
            Depth = depth;
        }

        public IEnumerable<State> GetAdjacentStates()
        {
            yield return new State(X, Y + 1, Depth + 1);
            yield return new State(X + 1, Y, Depth + 1);

            if (Y > 0)
                yield return new State(X, Y - 1, Depth + 1);

            if (X > 0)
                yield return new State(X - 1, Y, Depth + 1);
        }

        public bool Equals(State other)
        {
            return ToString() == other.ToString();
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", X, Y);
        }
    }

    public class Solver
    {
        readonly int _favoriteNumber;

        public Solver(string input)
        {
            _favoriteNumber = int.Parse(input);
        }

        public int FindMinimumStepsBetween(int startX, int startY, int endX, int endY)
        {
            var visited = new HashSet<string>();

            var queue = new Queue<State>();
            queue.Enqueue(new State(startX, startY));

            while (queue.Count > 0)
            {
                var parent = queue.Dequeue();

                var children = parent.GetAdjacentStates()
                    .Where(s => !visited.Contains(s.ToString()))
                    .Where(s => !IsWall(s.X, s.Y));

                if (children == null || children.Count() == 0) continue;

                foreach (var child in children)
                {
                    visited.Add(child.ToString());

                    if (child.X == endX && child.Y == endY)
                        return child.Depth;
                    else
                        queue.Enqueue(child);
                }
            }

            return 0;
        }

        public int LocationsWithinSteps(int startX, int startY, int steps)
        {
            var visited = new HashSet<string>();

            var queue = new Queue<State>();
            queue.Enqueue(new State(startX, startY));

            while (queue.Count > 0)
            {
                var parent = queue.Dequeue();

                var children = parent.GetAdjacentStates()
                    .Where(s => !visited.Contains(s.ToString()))
                    .Where(s => !IsWall(s.X, s.Y));

                if (children == null || children.Count() == 0) continue;

                foreach (var child in children)
                {
                    if (child.Depth > steps)
                        return visited.Count;

                    visited.Add(child.ToString());
                    queue.Enqueue(child);
                }
            }

            return 0;
        }


        internal bool IsWall(int x, int y)
        {
            var formula = (x * x) + (3 * x) + (2 * x * y) + y + (y * y);
            var checksum = formula + _favoriteNumber;
            var bits = CountBits(checksum);

            return (bits % 2 == 1);
        }

        static int CountBits(int n)
        {
            int count = 0;
            while (n != 0)
            {
                count++;
                n &= (n - 1);
            }
            return count;
        }

    }
}
