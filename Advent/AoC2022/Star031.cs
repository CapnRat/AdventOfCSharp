using System.Collections.Generic;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 3, 1)]
    public class Star031 : Solution<int>
    {
        public override int Run(string input)
        {
            int priority = 0;
            
            var left = new HashSet<char>();
            var right = new HashSet<char>();
            foreach (var line in Utility.InputToLines(input))
            {
                left.Clear();
                right.Clear();
                for (int l = 0, r = line.Length / 2; l < line.Length / 2; l++, r++)
                {
                    left.Add(line[l]);
                    right.Add(line[r]);
                }

                var intersection = left.Intersect(right);
                foreach (var c in intersection)
                {
                    if (char.IsLower(c))
                        priority += c - 'a' + 1;
                    else
                        priority += c - 'A' + 27;
                }
            }

            return priority;
        }
    }
}