using System;
using System.Collections.Generic;
using System.Linq;

namespace AocSolutionsCSharp.Day05
{
    static class Solution
    {
        public static int Part1(string input)
        {
            return React(input);
        }

        private static int React(string input)
        {
            var stack = new Stack<char>();
            
            foreach (var c in input.ToCharArray())
            {
                if (stack.Count == 0)
                    stack.Push(c);
                else
                {
                    if ((c ^ stack.Peek()) == 32)
                        stack.Pop();
                    else
                        stack.Push(c);
                }
            }

            return stack.Count;
        }
        
        public static int Part2(string input)
        {
            var sizes = new List<int>();
            var alphabet = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            foreach (var letter in alphabet)
            {
                var x = input.Replace(letter, "").Replace(letter.ToUpperInvariant(), "");
                sizes.Add(React(x));
            }

            return sizes.Min();
        }

    }
}

