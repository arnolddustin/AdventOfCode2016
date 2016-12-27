using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day16
{
    public class Solver
    {
        internal static string Solve(string input, int disklength)
        {
            var s = DragonCurve(input, disklength).Substring(0, disklength);

            return Checksum(s);
        }

        internal static string Checksum(string input)
        {
            if (input.Length % 2 == 1) throw new Exception("input must be even length");

            var sb = new StringBuilder();
            for (int i = 0; i < input.Length; i = i + 2)
                sb.Append(input[i] == input[i + 1] ? 1 : 0);

            var result = sb.ToString();

            if (result.Length % 2 == 1) return result;

            return Checksum(result);
        }

        internal static string DragonCurve(string input, int minlength)
        {
            if (input.Length >= minlength) return input;

            return DragonCurve(DragonCurveSegment(input), minlength);
        }

        internal static string DragonCurveSegment(string input)
        {
            var b = Reverse(input).Replace("1", "x").Replace("0", "1").Replace("x", "0");
            return string.Format("{0}0{1}", input, b);
        }

        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
