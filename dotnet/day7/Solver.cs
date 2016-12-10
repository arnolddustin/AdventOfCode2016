using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dotnet.day7
{
    public class Solver
    {
        public int LinesThatSupportProtocol(IEnumerable<string> input)
        {
            var lines = ProtocolFilter(input);

            return lines.Count();
        }

        private IEnumerable<string> ProtocolFilter(IEnumerable<string> input)
        {
            foreach (var line in input)
                if (SupportsProtocol(line))
                    yield return line;
        }

        internal bool SupportsProtocol(string line)
        {
            if (GetSegments(line, false).Any(s => ContainsABBA(s)))
                if (GetSegments(line, true).Count(s => ContainsABBA(s)) == 0)
                    return true;

            return false;
        }

        internal IEnumerable<string> GetSegments(string line, bool insideBrackets = false)
        {
            var pattern = @"\[(.*?)\]";
            var splits = new List<string>();
            foreach (Match match in Regex.Matches(line, pattern))
                splits.Add(match.Groups[0].Value);

            if (insideBrackets)
                foreach (var split in splits)
                    yield return split;
            else
            {
                int currentIndex = 0;
                for (int i = 0; i < splits.Count; i++)
                {
                    var nextIndex = line.IndexOf(splits[i]);
                    yield return line.Substring(currentIndex, nextIndex - currentIndex);
                    currentIndex = nextIndex + splits[i].Length;
                }

                yield return line.Substring(line.IndexOf(splits.Last()) + splits.Last().Length);
            }
        }

        internal bool ContainsABBA(string input)
        {
            string pattern = @"(.)(.)\2\1";
            foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
                if (match.Groups[0].Value[0] != match.Groups[0].Value[1])
                    return true;

            return false;
        }
    }
}
