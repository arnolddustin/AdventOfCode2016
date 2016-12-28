using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day17
{
    public enum Directions { Up, Down, Left = 4, Right = 8 }

    public class State : IEquatable<State>
    {
        char[] _unlocked = new char[] { 'b', 'c', 'd', 'e', 'f' };

        public int X { get; private set; }
        public int Y { get; private set; }
        public string History { get; private set; }

        public State(int x, int y, string history)
        {
            X = x;
            Y = y;
            History = history;
        }

        public bool Equals(State other)
        {
            return ToString() == other.ToString();
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", X, Y, History);
        }

        internal IEnumerable<Directions> GetAllowedDirections(string password)
        {
            var hash = GenerateHash(password);

            if (Y > 0 && _unlocked.Contains(hash[0]))
                yield return Directions.Up;

            if (Y < 3 && _unlocked.Contains(hash[1]))
                yield return Directions.Down;

            if (X > 0 && _unlocked.Contains(hash[2]))
                yield return Directions.Left;

            if (X < 3 && _unlocked.Contains(hash[3]))
                yield return Directions.Right;
        }

        public IEnumerable<State> GetChildStates(string password)
        {
            foreach (var direction in GetAllowedDirections(password))
            {
                switch (direction)
                {
                    case Directions.Up:
                        yield return new State(X, Y - 1, History + "U");
                        break;

                    case Directions.Down:
                        yield return new State(X, Y + 1, History + "D");
                        break;

                    case Directions.Left:
                        yield return new State(X - 1, Y, History + "L");
                        break;

                    case Directions.Right:
                        yield return new State(X + 1, Y, History + "R");
                        break;
                }
            }
        }
        internal string GenerateHash(string password)
        {
            using (var md5 = MD5.Create())
            {
                var md5input = System.Text.Encoding.ASCII.GetBytes(string.Format("{0}{1}", password, History));
                var hash = md5.ComputeHash(md5input);

                var sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                    sb.Append(hash[i].ToString("X2"));

                return sb.ToString().ToLower().Substring(0, 4);
            }
        }
    }

    public class Solver
    {
        readonly string _passcode;

        public Solver(string input)
        {
            _passcode = input;
        }

        public string FindShortestPathTo(int x, int y)
        {
            var visited = new HashSet<string>();

            var queue = new Queue<State>();
            queue.Enqueue(new State(0, 0, string.Empty));

            while (queue.Count > 0)
            {
                var parent = queue.Dequeue();

                var children = parent.GetChildStates(_passcode)
                    .Where(s => !visited.Contains(s.ToString()));

                if (children == null || children.Count() == 0) continue;

                foreach (var child in children)
                {
                    visited.Add(child.ToString());

                    if (child.X == x && child.Y == y)
                        return child.History;
                    else
                        queue.Enqueue(child);
                }
            }

            return string.Empty;
        }

        public int FindLongestPathStepsTo(int x, int y)
        {
            var visited = new HashSet<string>();
            int longestPath = 0;

            var queue = new Queue<State>();
            queue.Enqueue(new State(0, 0, string.Empty));

            while (queue.Count > 0)
            {
                var parent = queue.Dequeue();

                var children = parent.GetChildStates(_passcode)
                    .Where(s => !visited.Contains(s.ToString()));

                if (children == null || children.Count() == 0) continue;

                foreach (var child in children)
                {
                    visited.Add(child.ToString());

                    if (child.X == x && child.Y == y)
                    {
                        if (child.History.Length > longestPath)
                            longestPath = child.History.Length;

                        continue;
                    }
                    else
                        queue.Enqueue(child);
                }
            }

            return longestPath;
        }
    }
}
