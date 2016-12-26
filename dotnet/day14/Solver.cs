using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day14
{
    public class Solver
    {
        readonly string _salt;
        readonly Dictionary<int, string> _hashes;

        public Solver(string salt)
        {
            _salt = salt;
            _hashes = new Dictionary<int, string>();
        }

        public IEnumerable<int> GetIndexes(int howMany)
        {
            var currentCount = 0;
            var index = 0;

            while (true)
            {
                var hash = GetHashForIndex(index);
                var triple = GetFirstTriple(hash);

                if (triple.HasValue && HasFiveWithinRange(triple.Value, index))
                {
                    yield return index;
                    currentCount++;
                }

                if (currentCount == howMany)
                    break;

                index++;
            }

        }

        bool HasFiveWithinRange(char character, int index)
        {
            var attempts = 0;
            var currentIndex = index + 1;

            while (attempts < 1000)
            {
                var hashcode = GetHashForIndex(currentIndex);

                if (hashcode.Contains(new string(character, 5)))
                    return true;

                currentIndex++;
                attempts++;
            }

            return false;
        }

        char? GetFirstTriple(string s)
        {
            string pattern = @"(.)\1\1";

            Match match = Regex.Match(s, pattern);
            if (match.Success)
                return match.Groups[0].Value.First();

            return null;
        }

        string GetHashForIndex(int index)
        {
            if (!_hashes.ContainsKey(index))
            {
                using (var md5 = MD5.Create())
                {
                    var md5input = System.Text.Encoding.ASCII.GetBytes(string.Format("{0}{1}", _salt, index));
                    var hash = md5.ComputeHash(md5input);

                    var sb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                        sb.Append(hash[i].ToString("X2"));

                    _hashes.Add(index, sb.ToString().ToLower());
                }
            }

            return _hashes[index];
        }
    }
}
