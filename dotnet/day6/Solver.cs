using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dotnet.day6
{
    public class Solver
    {
        public string DecodeMessage(IEnumerable<string> input)
        {
            var list = new List<string>(input);

            var sb = new StringBuilder();

            for (int i = 0; i < list.First().Length; i++)
            {
                var column = input.Select(x => x.ElementAt(i));
                var mostFrequent = column.GroupBy(c => c).OrderByDescending(g => g.Count()).Select(x => x.Key).FirstOrDefault();
                sb.Append(mostFrequent);
            }

            return sb.ToString();
        }

        public string DecodeMessageReverse(IEnumerable<string> input)
        {
            var list = new List<string>(input);

            var sb = new StringBuilder();

            for (int i = 0; i < list.First().Length; i++)
            {
                var column = input.Select(x => x.ElementAt(i));
                var mostFrequent = column.GroupBy(c => c).OrderBy(g => g.Count()).Select(x => x.Key).FirstOrDefault();
                sb.Append(mostFrequent);
            }

            return sb.ToString();
        }
    }
}
