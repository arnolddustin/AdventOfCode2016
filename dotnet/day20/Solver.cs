using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day20
{
    class Range
    {
        public Int64 Min { get; set; }
        public Int64 Max { get; set; }

        public Range(Int64 min, Int64 max)
        {
            Min = min;
            Max = max;
        }
    }

    public class Solver
    {
        const long MAX = 4294967295;
        readonly List<Range> _ranges;

        public Solver(IEnumerable<string> instructions)
        {
            _ranges = new List<Range>();

            foreach (var instruction in instructions)
            {
                var split = instruction.Split('-');
                var start = long.Parse(split[0]);
                var end = long.Parse(split[1]);

                _ranges.Add(new Range(start, end));
            }
        }

        public long GetLowestUnblockedIP()
        {
            var merged = MergeRanges(_ranges).ToList();

            long n = 0;
            while (n < MAX)
            {
                if (!merged.Any(r => r.Min <= n && r.Max >= n))
                    return n;
                n++;
            }

            return -1;
        }

        static IEnumerable<Range> MergeRanges(IEnumerable<Range> ranges)
        {
            // sort by beginning of ranges
            var list = ranges.OrderBy(r => r.Min).ToList();

            // put first range on a stack
            var s = new Stack<Range>();
            s.Push(list.First());

            // loop through the rest
            for (int i = 1; i < list.Count(); i++)
            {
                var top = s.Peek();

                // no overlap - push to stack
                if (top.Max < list[i].Min)
                {
                    s.Push(list[i]);
                    continue;
                }

                // extends - replace top of stack with extended range
                if (top.Max < list[i].Max)
                {
                    top.Max = list[i].Max;
                    s.Pop();
                    s.Push(top);
                }
            }

            return s.AsEnumerable();
        }
    }
}
