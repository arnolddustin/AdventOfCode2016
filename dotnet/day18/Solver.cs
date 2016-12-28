using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day18
{
    public class Solver
    {
        readonly string _firstRow;

        public Solver(string input)
        {
            _firstRow = input;
        }

        public int GetSafeTileCount(int rowcount)
        {
            var total = _firstRow.Count(r => r == '.');

            var rows = GetNextRows(rowcount);

            foreach (var row in rows)
                total += row.Count(r => r == '.');

            return total;
        }

        public IEnumerable<string> GetNextRows(int rowcount)
        {
            var lastrow = _firstRow;

            for (int i = 0; i < rowcount; i++)
            {
                var sb = new StringBuilder();
                for (int j = 0; j < lastrow.Count(); j++)
                {
                    var l = (j == 0 || lastrow[j - 1] == '.');
                    var c = (lastrow[j] == '.');
                    var r = (j == lastrow.Count() - 1 || lastrow[j + 1] == '.');

                    if ((!l && !c && r))
                    {
                        sb.Append('^');
                        continue;
                    }

                    if ((!c && !r) && l)
                    {
                        sb.Append('^');
                        continue;
                    }

                    if (!l && c && r)
                    {
                        sb.Append('^');
                        continue;
                    }

                    if (l && c && !r)
                    {
                        sb.Append('^');
                        continue;
                    }

                    sb.Append('.');
                }

                lastrow = sb.ToString();
                yield return lastrow;
            }
        }
    }
}
