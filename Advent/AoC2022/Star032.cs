using System;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 3,2)]
    public class Star032 : Solution<int>
    {
        public override int Run(string input)
        {
            int priority = 0;
            
            var lines = Utility.InputToLines(input).ToArray();
            for (int i = 0; i < lines.Length; i += 3)
            {
                var c = lines[i].Intersect(lines[i + 1]).Intersect(lines[i + 2]).First();
                
                if (char.IsLower(c))
                    priority += c - 'a' + 1;
                else
                    priority += c - 'A' + 27;
            }

            return priority;
        }
    }
}