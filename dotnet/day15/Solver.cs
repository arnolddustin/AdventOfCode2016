using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day15
{
    public class Disc
    {
        readonly int _number;
        readonly int _size;
        readonly int _initialPosition;

        public Disc(int number, int size, int initialPosition)
        {
            _number = number;
            _size = size;
            _initialPosition = initialPosition;
        }

        public bool IsOpen(int t)
        {
            return (_initialPosition + t + _number) % _size == 0;
        }
    }

    public class Solver
    {
        public int Solve(IEnumerable<string> input)
        {
            return Solve(CreateDiscsFromInput(input));
        }

        IEnumerable<Disc> CreateDiscsFromInput(IEnumerable<string> input)
        {
            foreach (var s in input)
            {
                var number = int.Parse(s.Substring(6, 1));
                var size = int.Parse(s.Substring(12, 2).TrimEnd(' '));
                var position = int.Parse(s.Substring(s.IndexOf("ion ") + 4).TrimEnd('.'));

                yield return new Disc(number, size, position);
            }
        }

        internal int Solve(IEnumerable<Disc> discs)
        {
            var t = 0;
            while (true)
            {
                if (discs.All(d => d.IsOpen(t)))
                    return t;

                t++;
            }
        }
    }
}
