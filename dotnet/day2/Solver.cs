using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.day2
{
    public interface IKeypadLayout
    {
        IEnumerable<IEnumerable<string>> GetButtons();
    }

    public class NormalKeypadLayout : IKeypadLayout
    {
        public IEnumerable<IEnumerable<string>> GetButtons()
        {
            var list = new List<List<string>>();

            list.Add(new List<string>(new string[] { "1", "2", "3" }));
            list.Add(new List<string>(new string[] { "4", "5", "6" }));
            list.Add(new List<string>(new string[] { "7", "8", "9" }));

            return list;
        }
    }
    public class AdvancedKeypadLayout : IKeypadLayout
    {
        public IEnumerable<IEnumerable<string>> GetButtons()
        {
            var list = new List<List<string>>();

            list.Add(new List<string>(new string[] { " ", " ", "1", " ", " " }));
            list.Add(new List<string>(new string[] { " ", "2", "3", "4", " " }));
            list.Add(new List<string>(new string[] { "5", "6", "7", "8", "9" }));
            list.Add(new List<string>(new string[] { " ", "A", "B", "C", " " }));
            list.Add(new List<string>(new string[] { " ", " ", "D", " ", " " }));

            return list;
        }
    }

    public class Solver
    {
        readonly List<Tuple<string, int, int>> _keypad;

        public Solver(IKeypadLayout keypadLayout)
        {
            _keypad = new List<Tuple<string, int, int>>();

            var x = 0;
            var y = 0;

            foreach (var row in keypadLayout.GetButtons())
            {
                foreach (var col in row)
                {
                    _keypad.Add(new Tuple<string, int, int>(col, x, y));
                    y++;
                }

                x++;
                y = 0;
            }
        }

        public string GetCodeFromInput(IEnumerable<string> input, string startingButton)
        {
            var sb = new StringBuilder();

            var currentKey = _keypad.Single(k => k.Item1 == startingButton);

            foreach (var line in input)
            {
                foreach (var move in line)
                    currentKey = GetAdjacentKey(currentKey.Item2, currentKey.Item3, move) ?? currentKey;

                sb.Append(currentKey.Item1);
            }

            return sb.ToString();
        }

        Tuple<string, int, int> GetAdjacentKey(int x, int y, char direction)
        {
            switch (direction)
            {
                case 'L':
                    return _keypad.FirstOrDefault(k => !string.IsNullOrWhiteSpace(k.Item1) && k.Item2 == x && k.Item3 == y - 1);

                case 'R':
                    return _keypad.FirstOrDefault(k => !string.IsNullOrWhiteSpace(k.Item1) && k.Item2 == x && k.Item3 == y + 1);

                case 'U':
                    return _keypad.FirstOrDefault(k => !string.IsNullOrWhiteSpace(k.Item1) && k.Item2 == x - 1 && k.Item3 == y);

                case 'D':
                    return _keypad.FirstOrDefault(k => !string.IsNullOrWhiteSpace(k.Item1) && k.Item2 == x + 1 && k.Item3 == y);
            }

            return null;
        }
    }
}
