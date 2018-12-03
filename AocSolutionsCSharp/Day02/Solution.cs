using System;
using System.Collections.Generic;
using System.Linq;

namespace AocSolutionsCSharp.Day02
{
    static class Solution
    {
        public static int Part1(string input)
        {
            var ids = input.Split('\n');

            var pairs = 0;
            var triplets = 0;

            foreach (var id in ids)
            {
                var letters = new Dictionary<char, int>();
                foreach (var letter in id)
                {
                    if (!letters.ContainsKey(letter))
                        letters.Add(letter,0);
                    letters[letter]++;
                }

                var counts = letters.Values;
                var hasAPair = counts.Any(x => x == 2);
                var hasATriplet = counts.Any(x => x == 3);

                if(hasAPair)
                    pairs++;
                if(hasATriplet)
                    triplets++;
            }

            return pairs * triplets;
        }

        internal static bool OnlyDifferInOneCharacter(string v1, string v2)
        {
            var differences = 0;
            var x = v1.ToCharArray();
            var y = v2.ToCharArray();

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                    differences++;
            }

            return differences == 1;
        }

        internal static string FindCommonCharacters(string v1, string v2)
        {
            string xDiff ="";

            var x = v1.ToCharArray();
            var y = v2.ToCharArray();

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                    xDiff = x[i].ToString();

            }

            return v1.Replace(xDiff, "");
        }

        public static string Part2(string input)
        {
            var ids = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            var matches = FindIdsThatDiffereByOneCharacter(ids);
                       
            return FindCommonCharacters(matches.Item1, matches.Item2);
        }

        private static Tuple<string, string> FindIdsThatDiffereByOneCharacter(string[] ids)
        {
            foreach (var x in ids)
            {
                foreach (var y in ids)
                {
                    if (x == y)
                        continue;

                    if (OnlyDifferInOneCharacter(x, y))
                    {
                        return new Tuple<string, string>(x, y);
                    }
                }
            }
            return null;
        }
    }
}
