using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day21
{
    public static class Instructions
    {
        public static string SwapPosition(this string s, int position1, int position2)
        {
            var sb = new StringBuilder();

            var value1 = s[position1];
            var value2 = s[position2];

            for (int i = 0; i < s.Length; i++)
            {
                if (i == position1)
                    sb.Append(value2);
                else if (i == position2)
                    sb.Append(value1);
                else
                    sb.Append(s[i]);
            }

            return sb.ToString();
        }

        public static string SwapLetter(this string s, char letter1, char letter2)
        {
            return s.Replace(letter1, '|').Replace(letter2, letter1).Replace('|', letter2);
        }

        public static string RotateLeft(this string s, int steps)
        {
            var result = s;

            for (int i = 0; i < steps; i++)
            {
                var first = result.First();
                result = string.Format("{0}{1}", result.Substring(1), first);
            }

            return result;
        }

        public static string RotateRight(this string s, int steps)
        {
            var result = s;

            for (int i = 0; i < steps; i++)
            {
                var last = result.Last();
                result = string.Format("{0}{1}", last, result.Substring(0, result.Length - 1));
            }

            return result;
        }

        public static string RotateBaseOnLetterPosition(this string s, char letter)
        {
            var index = s.IndexOf(letter);

            var rotations = 1 + index + ((index > 3) ? 1 : 0);

            return s.RotateRight(rotations);
        }

        public static string ReversePositions(this string s, int start, int end)
        {
            var sb = new StringBuilder();

            var length = end - start + 1;
            var segment = s.Substring(start, length).Reverse().ToArray();

            return string.Format("{0}{1}{2}", s.Substring(0, start), new string(segment), s.Substring(end + 1));
        }

        public static string MovePosition(this string s, int x, int y)
        {
            var letter = s[x];

            var result = string.Format("{0}{1}", s.Substring(0, x), s.Substring(x + 1));

            return result.Insert(y, letter.ToString());
        }
    }

    public class Solver
    {
        readonly string _password;
        readonly List<string> _instructions;

        public Solver(string password, IEnumerable<string> instructions)
        {
            _password = password;
            _instructions = new List<string>(instructions);
        }

        public string GetScrambledPassword()
        {
            var result = _password;
            foreach (var instruction in _instructions)
                result = ProcessInstruction(result, instruction);
            return result;
        }

        public string ProcessInstruction(string input, string instruction)
        {
            if (instruction.StartsWith("swap position"))
            {
                var p1 = int.Parse(instruction.Substring(14, 1));
                var p2 = int.Parse(instruction.Substring(instruction.LastIndexOf(' ') + 1));

                return input.SwapPosition(p1, p2);
            }

            if (instruction.StartsWith("swap letter"))
            {
                var l1 = instruction[12];
                var l2 = instruction[26];

                return input.SwapLetter(l1, l2);
            }

            if (instruction.StartsWith("reverse positions"))
            {
                var p1 = int.Parse(instruction.Substring(18, 1));
                var p2 = int.Parse(instruction.Substring(28));

                return input.ReversePositions(p1, p2);
            }

            if (instruction.StartsWith("move position"))
            {
                var p1 = int.Parse(instruction.Substring(14, 1));
                var p2 = int.Parse(instruction.Substring(28));

                return input.MovePosition(p1,p2);
            }

            if (instruction.StartsWith("rotate left"))
            {
                var i = int.Parse(instruction.Substring(12, 1));
                return input.RotateLeft(i);
            }

            if (instruction.StartsWith("rotate right"))
            {
                var i = int.Parse(instruction.Substring(12, 2));
                return input.RotateRight(i);
            }

            if (instruction.StartsWith("rotate based"))
            {
                var c = instruction.Last();
                return input.RotateBaseOnLetterPosition(c);
            }

            throw new ApplicationException("unknown instruction: " + instruction);
        }

    }
}
