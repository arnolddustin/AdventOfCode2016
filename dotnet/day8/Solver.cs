using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day8
{
    internal class Screen
    {
        readonly List<List<char>> _pixels;

        public Screen(int width, int height)
        {
            _pixels = new List<List<char>>();

            for (int y = 0; y < height; y++)
                _pixels.Add(new List<char>(new string('.', width).ToCharArray()));
        }

        public void Rect(int x, int y)
        {
            for (int i = 0; i < y; i++)
                for (int j = 0; j < x; j++)
                    _pixels[i][j] = '#';
        }

        public void RotateColumn(int x, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var column = ShiftRight(_pixels.Select(row => row.ElementAt(x))).ToList();

                for (int j = 0; j < _pixels.Count; j++)
                    _pixels[j][x] = column[j];
            }
        }

        public void RotateRow(int y, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var row = ShiftRight(_pixels[y]);
                _pixels[y] = new List<char>(row);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var row in _pixels)
                sb.AppendFormat("{0}|", string.Concat(row));

            return sb.ToString().TrimEnd('|');
        }

        public int CountLitPixels()
        {
            return _pixels.SelectMany(row => row.Where(column => column == '#')).Count();
        }

        internal IEnumerable<char> ShiftRight(IEnumerable<char> list)
        {
            yield return list.Last();

            for (int i = 0; i < list.Count() - 1; i++)
                yield return list.ElementAt(i);

        }
    }

    public class Solver
    {
        readonly Screen _screen;

        public Solver(int screenWidth, int screenHeight)
        {
            _screen = new Screen(screenWidth, screenHeight);
        }

        public int HowManyPixelsAreLit(IEnumerable<string> instructions)
        {
            foreach (var line in instructions)
                ProcessInstruction(line);

            return _screen.CountLitPixels();
        }

        public void ProcessInstruction(string line)
        {
            if (line.StartsWith("rect"))
            {
                var firstlength = line.IndexOf('x') - 5;
                var x = int.Parse(line.Substring(5, firstlength));
                var y = int.Parse(line.Split('x')[1]);
                _screen.Rect(x, y);
            }

            if (line.StartsWith("rotate row"))
            {
                var y = int.Parse(line.Substring(13, 1));
                var count = int.Parse(line.Substring(18));
                _screen.RotateRow(y, count);
            }

            if (line.StartsWith("rotate column"))
            {
                var start = 16;
                var length = line.IndexOf(" by") - 16;
                var x = int.Parse(line.Substring(start, length));
                var count = int.Parse(line.Substring(line.IndexOf("by ") + 3));
                _screen.RotateColumn(x, count);
            }
        }

        public override string ToString()
        {
            return _screen.ToString();
        }
    }
}
