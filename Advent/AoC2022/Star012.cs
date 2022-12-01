using System.Collections.Generic;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 1, 2)]
    public class Star012 : Solution<int>
    {
        public override int Run(string input)
        {
            var amounts = new List<int>{0};
            foreach (var line in Utility.InputToLines(input))
            {
                if (string.IsNullOrEmpty(line))
                {
                    amounts.Add(0);
                    continue;
                }

                amounts[^1] += int.Parse(line);
            }
            
            amounts.Sort();

            return amounts.ToArray()[^3..].Sum();
        }
    }
}