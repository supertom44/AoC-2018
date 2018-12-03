using System;
using System.Collections.Generic;
using System.Linq;

namespace AocSolutionsCSharp.Day03
{
    static class Solution
    {
        public struct Claim
        {
            public Claim(string id, Tuple<int, int> topLeftCorner, int width, int height)
            {
                Id = id.Trim();
                TopLeftCorner = topLeftCorner;
                Width = width;
                Height = height;
            }

            public string Id { get; }
            public Tuple<int, int> TopLeftCorner { get; }
            public int Width { get; }
            public int Height { get; }
        }

        private static Claim ParseToClaim(string claim)
        {
            var parts = claim.Split('@', ':');
            var position = parts[1].Split(',');
            var size = parts[2].Split('x');
            return new Claim(parts[0], new Tuple<int, int>(int.Parse(position[0]), int.Parse(position[1])), int.Parse(size[0]), int.Parse(size[1]));
        }

        private static List<Tuple<int, int>> Expand(Claim claim)
        {
            var cordinates = new List<Tuple<int, int>>();
            var startX = claim.TopLeftCorner.Item1;
            var startY = claim.TopLeftCorner.Item2;


            for (int x = 1; x <= claim.Width; x++)
            {
                for (int y = 1; y <= claim.Height; y++)
                {
                    cordinates.Add(new Tuple<int, int>(startX + x, startY + y));
                }
            }

            return cordinates;
        }


        public static int Part1(string input)
        {
            var claims = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).Select(ParseToClaim);

            var coordinates = claims.SelectMany(Expand);

            var claimedCoordinates = coordinates.GroupBy(x => x);

            var overlaps = claimedCoordinates.Where(x => x.Count() > 1);

            return overlaps.Count();
        }


        public static string Part2(string input)
        {
            var claims = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).Select(ParseToClaim);

            var coordinates = claims.SelectMany(Expand);

            var claimedCoordinates = coordinates.GroupBy(x => x);

            var overlaps = claimedCoordinates.Where(x => x.Count() > 1);

            var overlapSet = new HashSet<Tuple<int,int>>(overlaps.Select(x => x.Key));

            foreach (var claim in claims)
            {
                var claimCoordinats = Expand(claim);
                var claimsSet = new HashSet<Tuple<int, int>>(claimCoordinats);
                var intersect = claimsSet.Intersect(overlapSet);
                if (intersect.Count() == 0)
                    return claim.Id;
            }

            return null;
        }

    }
}
