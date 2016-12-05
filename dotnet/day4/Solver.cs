using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dotnet.day4
{
    public class Solver
    {
        public int GetSumOfSectorIdsForRealRooms(IEnumerable<string> input)
        {
            var total = 0;

            foreach (var line in input)
            {
                total = total + GetSectionIdToAdd(line);
            }

            return total;
        }

        int GetSectionIdToAdd(string room)
        {
            var regex = new Regex(@"(?<sectionid>\d+)");
            var match = regex.Match(room);
            var sectionId = match.Groups["sectionid"].Value;

            var parts = room.Split(sectionId.ToCharArray());

            if (MatchesChecksum(parts[0], parts[3]))
                return int.Parse(sectionId);

            return 0;
        }

        bool MatchesChecksum(string encrypted, string checksum)
        {
            var cleaned = encrypted.Replace("-", "");
            var ordered = String.Concat(cleaned.OrderBy(c => c));
            var commons = ordered.GroupBy(x => x).OrderByDescending(x => x.Count()).Take(5);

            var calculated = string.Format("[{0}]", string.Concat(commons.Select(x => x.Key)));

            return calculated == checksum;
        }
    }
}
