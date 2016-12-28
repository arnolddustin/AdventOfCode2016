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
        public long Min { get; set; }
        public long Max { get; set; }

        public Range(long min, long max)
        {
            Min = min;
            Max = max;
        }

        public bool IsInclusiveOf(long n)
        {
            return Min <= n && Max >= n;
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
            return GetAllowedIps(_ranges).Min(r => r);
        }

        public long GetAllowedIpCount()
        {
            return GetAllowedIps(_ranges).Count();
        }

        static IEnumerable<long> GetAllowedIps(IEnumerable<Range> ranges)
        {
            var merged = MergeRanges(ranges);
            var stack = new Stack<Range>(merged);

            List<long> allowedIps = new List<long>();

            long current = 0;
            while (stack.Count > 0)
            {
                var range = stack.Pop();

                if (range.IsInclusiveOf(current))
                {
                    current = range.Max + 1;
                    continue;
                }

                if (current < range.Min)
                {
                    for (var i = current; i < range.Min; i++)
                        allowedIps.Add(i);

                    current = range.Max + 1;
                    continue;
                }
            }

            return allowedIps;
        }

        static IEnumerable<Range> MergeRanges(IEnumerable<Range> ranges)
        {
            var list = ranges.OrderBy(r => r.Min).ToList();

            var stack = new Stack<Range>();
            stack.Push(list.First());

            // loop through the rest
            for (int i = 1; i < list.Count(); i++)
            {
                var top = stack.Peek();

                // no overlap - push to stack
                if (top.Max <= list[i].Min)
                {
                    stack.Push(list[i]);
                    continue;
                }

                // extends - replace top of stack with extended range
                if (top.Max <= list[i].Max)
                {
                    top.Max = list[i].Max;
                    stack.Pop();
                    stack.Push(top);
                }
            }

            return stack;
        }
    }
}
