using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.day1
{
    public class Solver
    {
        readonly List<Vector> _movesHistory;
        readonly List<Point> _locationsHistory;

        public Solver()
        {
            _movesHistory = new List<Vector>();
            _locationsHistory = new List<Point>();
        }

        public int GetShortestPathToDestination(string input)
        {
            PerformMoves(input);

            var location = _movesHistory.Last();

            return Math.Abs(location.Point.X) + Math.Abs(location.Point.Y);
        }

        public int GetShortestPathToFirstLocationVisitedTwice(string input)
        {
            PerformMoves(input);

            var bucket = new List<Point>();
            foreach (var location in _locationsHistory)
            {
                if (bucket.Exists(p => p.X == location.X && p.Y == location.Y))
                    return Math.Abs(location.X) + Math.Abs(location.Y);

                bucket.Add(location);
            }

            return -1;
        }

        class Vector
        {
            public Point Point { get; set; }
            public int Direction { get; set; }

            public override string ToString()
            {
                return string.Format("[{0},{1}] -> {2}", Point.X, Point.Y, Direction);
            }
        }

        class Move
        {
            public string Direction { get; set; }
            public int Steps { get; set; }

            public override string ToString()
            {
                return Direction + Steps.ToString();
            }
        }

        IEnumerable<Move> ReadInput(string input)
        {
            foreach (var item in input.Replace(" ", "").Split(','))
            {
                var d = item.Substring(0, 1);
                var i = int.Parse(item.Substring(1));

                yield return new Move() { Direction = d, Steps = i };
            }
        }

        void PerformMoves(string input)
        {
            var moves = ReadInput(input);

            var v = new Vector() { Point = new Point(0, 0), Direction = 0 };
            _movesHistory.Clear();
            _movesHistory.Add(v);

            foreach (var move in moves)
            {
                v = MakeMove(v, move);
                _movesHistory.Add(v);
            }
        }

        Vector MakeMove(Vector current, Move move)
        {
            int newDirection = 0;

            if (move.Direction == "L")
            {
                newDirection = current.Direction - 90;
                if (newDirection < 0)
                    newDirection = 270;
            }

            if (move.Direction == "R")
            {
                newDirection = current.Direction + 90;
                if (newDirection == 360)
                    newDirection = 0;
            }

            var v = new Vector() { Direction = newDirection, Point = current.Point };
            switch (newDirection)
            {
                case 0:
                    for (var i = 0; i < move.Steps; i++)
                    {
                        v.Point = new Point(v.Point.X, v.Point.Y + 1);
                        _locationsHistory.Add(v.Point);
                    }
                    break;
                case 90:
                    for (var i = 0; i < move.Steps; i++)
                    {
                        v.Point = new Point(v.Point.X +1, v.Point.Y);
                        _locationsHistory.Add(v.Point);
                    }
                    break;
                case 180:
                    for (var i = 0; i < move.Steps; i++)
                    {
                        v.Point = new Point(v.Point.X, v.Point.Y -1);
                        _locationsHistory.Add(v.Point);
                    }
                    break;
                case 270:
                    for (var i = 0; i < move.Steps; i++)
                    {
                        v.Point = new Point(v.Point.X - 1, v.Point.Y);
                        _locationsHistory.Add(v.Point);
                    }
                    break;
            }
            return v;
        }
    }
}
