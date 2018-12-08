using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AocSolutionsCSharp.Day04
{
    static class Solution
    {

        public static int Part1(string input)
        {
            var shifts = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var guards = new Dictionary<int, List<int>>();

            var ordered = shifts.OrderBy(x =>
            {
                var groups = Regex.Match(x, @"\[(\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2})\].+").Groups;
                var year = int.Parse(groups[1].Value);
                var month = int.Parse(groups[2].Value);
                var day = int.Parse(groups[3].Value);
                var hour = int.Parse(groups[4].Value);
                var min = int.Parse(groups[5].Value);
                return new DateTime(year, month, day, hour, min,0);
            });

            int guard = 0;
            int startTime = 0;
            foreach (var shift in ordered)
            {
                var x = shift.Split(new[] { "] " }, StringSplitOptions.None)[1];
                if (x.StartsWith("G"))
                {
                    guard = int.Parse(Regex.Match(shift, @".+#(\d+)").Groups[1].Value);
                    if (!guards.ContainsKey(guard))
                        guards[guard] = new List<int>();

                    
                }
                if(x.StartsWith("f"))
                {
                    if (guard != 0)
                    {
                        startTime = int.Parse(Regex.Match(shift, @"\[\d{4}-\d{2}-\d{2} \d{2}:(\d{2})\].+").Groups[1].Value);
                    }
                }
                if (x.StartsWith("w"))
                {
                    var wakes = int.Parse(Regex.Match(shift, @"\[\d{4}-\d{2}-\d{2} \d{2}:(\d{2})\].+").Groups[1].Value);
                    for (int i = startTime; i < wakes; i++)
                    {
                        guards[guard].Add(i);
                    }
                }                
            }

            var maxSleepGuard = guards.Aggregate((x, y) => x.Value.Count() > y.Value.Count() ? x : y).Key;

            var minutesAlseep = guards[maxSleepGuard];
            var agg = minutesAlseep.GroupBy(x => x);
            var t = agg.OrderByDescending(x => x.Count()).First();

            return maxSleepGuard * t.Key;
        }


        public static int Part2(string input)
        {
            var shifts = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var guards = new Dictionary<int, List<int>>();

            var ordered = shifts.OrderBy(x =>
            {
                var groups = Regex.Match(x, @"\[(\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2})\].+").Groups;
                var year = int.Parse(groups[1].Value);
                var month = int.Parse(groups[2].Value);
                var day = int.Parse(groups[3].Value);
                var hour = int.Parse(groups[4].Value);
                var min = int.Parse(groups[5].Value);
                return new DateTime(year, month, day, hour, min, 0);
            });

            int guard = 0;
            int startTime = 0;
            foreach (var shift in ordered)
            {
                var x = shift.Split(new[] { "] " }, StringSplitOptions.None)[1];
                if (x.StartsWith("G"))
                {
                    guard = int.Parse(Regex.Match(shift, @".+#(\d+)").Groups[1].Value);
                    if (!guards.ContainsKey(guard))
                        guards[guard] = new List<int>();


                }
                if (x.StartsWith("f"))
                {
                    if (guard != 0)
                    {
                        startTime = int.Parse(Regex.Match(shift, @"\[\d{4}-\d{2}-\d{2} \d{2}:(\d{2})\].+").Groups[1].Value);
                    }
                }
                if (x.StartsWith("w"))
                {
                    var wakes = int.Parse(Regex.Match(shift, @"\[\d{4}-\d{2}-\d{2} \d{2}:(\d{2})\].+").Groups[1].Value);
                    for (int i = startTime; i < wakes; i++)
                    {
                        guards[guard].Add(i);
                    }
                }
            }
            var test = new Tuple<int, int>(1, 1);
            var groupedCounts = guards.Select(x => new Tuple<int, IEnumerable<IGrouping<int,int>>>(x.Key, x.Value.GroupBy(y => y)));
            
            var orderdedCounts = groupedCounts.Where(x => x.Item2.Count() != 0).OrderByDescending(x => x.Item2.Max(y => y.Count()));
            var guardAsleepMostOnSameMinute = orderdedCounts.First();
            var minuteAsleepTheMost = guardAsleepMostOnSameMinute.Item2.OrderByDescending(x => x.Count()).First().Key;


            return minuteAsleepTheMost * guardAsleepMostOnSameMinute.Item1;
        }

    }
}

