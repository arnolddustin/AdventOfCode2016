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
        readonly Dictionary<int, string> _stretchedHashes;

        public Solver(string salt)
        {
            _salt = salt;
            _hashes = new Dictionary<int, string>();
            _stretchedHashes = new Dictionary<int, string>();
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

        public IEnumerable<int> GetStretchedIndexes(int howMany)
        {
            var currentCount = 0;
            var index = 0;

            while (true)
            {
                var hash = GetStretchedHashForIndex(index);
                var triple = GetFirstTriple(hash);

                if (triple.HasValue && HasFiveStretchedWithinRange(triple.Value, index))
                {
                    yield return index;
                    currentCount++;
                }

                if (currentCount == howMany)
                    break;

                index++;
            }
        }

        bool HasFiveStretchedWithinRange(char character, int index)
        {
            var attempts = 0;
            var currentIndex = index + 1;

            while (attempts < 1000)
            {
                var hashcode = GetStretchedHashForIndex(currentIndex);

                if (hashcode.Contains(new string(character, 5)))
                    return true;

                currentIndex++;
                attempts++;
            }

            return false;
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
                _hashes.Add(index, GetHash(string.Format("{0}{1}", _salt, index)));

            return _hashes[index];
        }

        internal string GetStretchedHashForIndex(int index)
        {
            if (!_stretchedHashes.ContainsKey(index))
            {
                var current = GetHashForIndex(index);

                for (int i = 0; i < 2016; i++)
                    current = GetHash(current);

                _stretchedHashes.Add(index, current);
            }

            return _stretchedHashes[index];
        }

        string GetHash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var md5input = System.Text.Encoding.ASCII.GetBytes(input);
                var hash = md5.ComputeHash(md5input);

                var sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                    sb.Append(hash[i].ToString("X2"));

                return sb.ToString().ToLower();
            }
        }
    }
}
