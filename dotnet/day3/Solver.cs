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

                if (IsValidTriangle(s1, s2, s3))
                    total++;
            }

            return total;
        }

        public int GetValidVerticleTriangleCount(IEnumerable<string> input)
        {
            var total = 0;

            var list = new List<string>(input);

            for (int i = 0; i < list.Count; i += 3)
            {
                for (int j = 0; j < 15; j += 5)
                {
                    var s1 = int.Parse(list[i].Substring(j, 5));
                    var s2 = int.Parse(list[i + 1].Substring(j, 5));
                    var s3 = int.Parse(list[i + 2].Substring(j, 5));

                    if (IsValidTriangle(s1, s2, s3))
                        total++;
                }
            }

            return total;
        }

        bool IsValidTriangle(int s1, int s2, int s3)
        {
            return (s1 + s2 > s3 && s2 + s3 > s1 && s1 + s3 > s2);
        }
    }
}
