using System;
using System.Collections.Generic;
using System.Linq;

namespace AocSolutionsCSharp.Day01
{
    static class Solution
    {
        public static int Part1(string input)
        {
            var numbers = input.Split('\n').Select(x => Convert.ToInt32(x));
            return numbers.Sum();
        }

        public static int Part2(string input)
        {
            var numbers = input.Split('\n').Select(x => Convert.ToInt32(x));
            var frequicies = new HashSet<int>();
            var sum = 0;
            while (true)
            {
                foreach (var item in numbers)
                {
                    sum += item;
                    if (frequicies.Contains(sum))
                        return sum;
                    else
                        frequicies.Add(sum);
                }
            }
        }
    }
}
