using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dotnet.day4
{
    public class Room
    {
        public string EncryptedName { get; set; }
        public int SectorId { get; set; }
        public string Checksum { get; set; }

        public bool MatchesChecksum()
        {
            var cleaned = EncryptedName.Replace("-", "");
            var ordered = String.Concat(cleaned.OrderBy(c => c));
            var commons = ordered.GroupBy(x => x).OrderByDescending(x => x.Count()).Take(5);

            var calculated = string.Format("[{0}]", string.Concat(commons.Select(x => x.Key)));

            return calculated == Checksum;
        }
    }

    public class Solver
    {
        public int GetSumOfSectorIdsForRealRooms(IEnumerable<string> input)
        {
            var total = 0;

            foreach (var room in GetRooms(input).Where(r => r.MatchesChecksum()))
                total = total + room.SectorId;

            return total;
        }

        public int GetSectorIdOfRoomWithNorthPoleObjects(IEnumerable<string> input)
        {
            foreach (var room in GetRooms(input).Where(r => r.MatchesChecksum()))
            {
                if (DecipherName(room.EncryptedName, room.SectorId) == "northpole object storage")
                    return room.SectorId;
            }

            return 0;
        }

        public string DecipherName(string s, int sectorId)
        {
            var sb = new StringBuilder();

            foreach (var letter in s)
            {
                if (letter == '-')
                    sb.Append(" ");
                else
                    sb.Append(ReplaceLetter(letter, sectorId));
            }

            return sb.ToString();
        }

        char ReplaceLetter(char letter, int sectorId)
        {
            for (int i = 0; i < sectorId; i++)
            {
                letter++;

                if (letter > 'z')
                    letter = 'a';
            }

            return letter;
        }
        IEnumerable<Room> GetRooms(IEnumerable<string> input)
        {
            var regex = new Regex(@"(?<sectorid>\d+)");
            Match match;
            string sectorid;
            string[] parts;

            foreach (var line in input)
            {
                match = regex.Match(line);
                sectorid = match.Groups["sectorid"].Value;
                parts = line.Split(sectorid.ToCharArray());

                yield return new Room() { SectorId = int.Parse(sectorid), EncryptedName = parts[0].TrimEnd('-'), Checksum = parts[3] };
            }
        }
    }
}
