using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day9
{
    public class Solver
    {
        public int GetDecompressedLength(string line)
        {
            return DecompressString(line).Length;
        }

        internal string DecompressString(string s)
        {
            var regex = new Regex(@"\((?<markerleft>\d+)x(?<markerright>\d+)\)");

            var sb = new StringBuilder();

            Match match;
            var remaining = s;
            int left = -1;
            int right = -1;
            int length = -1;

            while (true)
            {
                match = regex.Match(remaining);

                if (match.Length == 0) // no more markers
                {
                    sb.Append(remaining);
                    break;
                }

                // everything before the next marker
                sb.Append(remaining.Substring(0, match.Index));

                // extract the next marker
                length = 3 + match.Groups["markerleft"].Value.Length + match.Groups["markerright"].Value.Length;
                left = int.Parse(match.Groups["markerleft"].Value);
                right = int.Parse(match.Groups["markerright"].Value);

                // get string to repeat
                var torepeat = remaining.Substring(match.Index + length, left);

                Console.WriteLine("repeating {0} for {1} times", torepeat, right);

                // add appended
                for (int i = 0; i < right; i++)
                    sb.Append(torepeat);

                remaining = remaining.Substring(match.Index + length + torepeat.Length);
                Console.WriteLine("remaining: '{0}'", remaining);
            }

            return sb.ToString();
        }

        public int GetAdvancedDecompressedLength(string line)
        {
            var decompressed = AdvancedDecompressString(line);

            return decompressed.Length;
        }

        internal string AdvancedDecompressString(string s)
        {
            var regex = new Regex(@"\((?<markerleft>\d+)x(?<markerright>\d+)\)");

            var sb = new StringBuilder();

            Match match;
            var remaining = s;
            int left = -1;
            int right = -1;
            int length = -1;

            while (true)
            {
                match = regex.Match(remaining);

                if (match.Length == 0) // no more markers
                {
                    sb.Append(remaining);
                    break;
                }

                // everything before the next marker
                sb.Append(remaining.Substring(0, match.Index));

                // extract the next marker
                length = 3 + match.Groups["markerleft"].Value.Length + match.Groups["markerright"].Value.Length;
                left = int.Parse(match.Groups["markerleft"].Value);
                right = int.Parse(match.Groups["markerright"].Value);

                // get string to repeat (truncate if longer than remaining string)
                var torepeat = (match.Index +length + left > remaining.Length) ? remaining.Substring(match.Index + length) : remaining.Substring(match.Index + length, left);
                var originalrepeatlength = string.IsNullOrEmpty(torepeat) ? 0 : torepeat.Length;

                // recurse
                if (regex.Match(torepeat).Captures.Count > 0)
                    torepeat = AdvancedDecompressString(torepeat);

                // add appended
                for (int i = 0; i < right; i++)
                    sb.Append(torepeat);

                remaining = remaining.Substring(match.Index + length + originalrepeatlength);
            }

            return sb.ToString();
        }

    }
}
