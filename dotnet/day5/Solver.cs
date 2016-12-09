using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dotnet.day5
{
    public class Solver
    {
        public string GetDoorPassword(int startingIndex, string doorId, int passwordLength)
        {
            var sb = new StringBuilder();

            var currentIndex = startingIndex;

            while (sb.Length < passwordLength)
            {
                var nextResult = GetFirstHashStartingWithFiveZeroes(doorId, currentIndex);

                sb.Append(nextResult.Item2[5]);

                currentIndex = nextResult.Item1 + 1;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns the index and the hash
        /// </summary>
        public Tuple<int, string> GetFirstHashStartingWithFiveZeroes(string s, int startingIndex)
        {
            var currentIndex = startingIndex;

            while (true)
            {
                using (var md5 = MD5.Create())
                {
                    var input = System.Text.Encoding.ASCII.GetBytes(s + currentIndex.ToString());
                    var hash = md5.ComputeHash(input);

                    var sb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("X2"));
                    }

                    var result = sb.ToString();

                    if (result.StartsWith("00000"))
                        return new Tuple<int, string>(currentIndex, result);

                    currentIndex++;
                }
            }
        }
    }
}
