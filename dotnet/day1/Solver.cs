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
        readonly List<Move> _moves;
        readonly List<Vector> _movesHistory;
        readonly List<Point> _locationsHistory;

        public Solver(string input)
        {
            _moves = new List<Move>(ReadInput(input));
            _movesHistory = new List<Vector>();
            _locationsHistory = new List<Point>();
        }

        public int GetShortestPathToDestination()
        {
            PerformMoves();

            return DistanceToCenter(_movesHistory.Last().Point);
        }

        public int GetShortestPathToFirstLocationVisitedTwice()
        {
            PerformMoves();

            var bucket = new List<Point>();
            foreach (var location in _locationsHistory)
            {
                if (bucket.Exists(p => p.X == location.X && p.Y == location.Y))
                    return DistanceToCenter(location);

                bucket.Add(location);
            }

            return -1;
        }

        class Vector
        {
            public Point Point { get; set; }
            public int Direction { get; set; }
        }

        class Move
        {
            public string Direction { get; set; }
            public int Steps { get; set; }
        }

        IEnumerable<Move> ReadInput(string input)
        {
            foreach (var item in input.Replace(" ", "").Split(','))
                yield return new Move()
                {
                    Direction = item.Substring(0, 1),
                    Steps = int.Parse(item.Substring(1))
                };
        }

        int DistanceToCenter(Point point)
        {
            return Math.Abs(point.X) + Math.Abs(point.Y);
        }

        void PerformMoves()
        {
            var v = new Vector() { Point = new Point(0, 0), Direction = 0 };
            _movesHistory.Clear();
            _movesHistory.Add(v);

            foreach (var move in _moves)
            {
                v = MakeMove(v, move);
                _movesHistory.Add(v);
            }
        }

        Vector MakeMove(Vector current, Move move)
        {
            var newDirection = (move.Direction == "L")
                ? (current.Direction == 0) ? 270 : current.Direction - 90
                : (current.Direction == 270) ? 0 : current.Direction + 90;

            var v = new Vector() { Direction = newDirection, Point = current.Point };

            var xOffset = 0;
            var yOffset = 0;

            switch (newDirection)
            {
                case 0:
                    yOffset = 1;
                    break;
                case 90:
                    xOffset = 1;
                    break;
                case 180:
                    yOffset = -1;
                    break;
                case 270:
                    xOffset = -1;
                    break;
            }

            for (var i = 0; i < move.Steps; i++)
            {
                v.Point = new Point(v.Point.X + xOffset, v.Point.Y + yOffset);
                _locationsHistory.Add(v.Point);
            }

            return v;
        }
    }
}
