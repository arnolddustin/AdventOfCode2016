using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet.day3
{
    public class Solver
    {
        public int GetValidTriangleCount(IEnumerable<string> input)
        {
            var total = 0;

            foreach (var line in input)
            {
                var s1 = int.Parse(line.Substring(0, 5));
                var s2 = int.Parse(line.Substring(5, 5));
                var s3 = int.Parse(line.Substring(10));

                if (s1 + s2 > s3 && s2 + s3 > s1 && s1 + s3 > s2)
                    total++;
            }

            return total;
        }
    }
}
