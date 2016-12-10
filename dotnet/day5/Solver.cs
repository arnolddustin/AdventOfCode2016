using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public string GetDoorAdvancedPassword(int startingIndex, string doorId)
        {
            const string PLACEHOLDER = " _ ";
            var password = new List<string>();
            for (int i = 0; i < 8; i++) { password.Add(PLACEHOLDER); };
            var complete = false;
            var currentIndex = startingIndex;
            
            while (!complete)
            {
                var nextResult = GetFirstHashStartingWithFiveZeroes(doorId, currentIndex);
                var sixthChar = nextResult.Item2[5];
                var seventhChar = nextResult.Item2[6];

                int newPosition;
                if (int.TryParse(sixthChar.ToString(), out newPosition))
                {
                    if (newPosition < 8 && password[newPosition] == PLACEHOLDER)
                    {
                        password[newPosition] = seventhChar.ToString();
                        Trace.WriteLine(string.Format("index {0} has hash of {1}. Using {2} for position {3} in password. Password is now {4}", currentIndex, nextResult.Item2, seventhChar, newPosition, string.Concat(password)));
                    }
                }

                if (password.Any(s => s == PLACEHOLDER))
                    currentIndex = nextResult.Item1 + 1;
                else
                    complete = true;
            }

            return string.Concat(password);
        }

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
