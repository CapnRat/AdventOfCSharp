using System.Collections.Generic;
using System.Linq;
using Advent.Common;
using Combinatorics.Collections;

namespace Advent.AoC2015
{
    [Solution(15,24,1)]
    public class Star241 : Solution
    {
        public override string Run(string input)
        {
            return Solve(input, 3);
        }

        public static string Solve(string input, int numGroups)
        {
            var packages = Utility.InputTo(long.Parse, input).ToArray();
            var groupMass = packages.Sum() / numGroups;

            for (int i = 2; i < packages.Length; i++)
            {
                var groups = new Combinations<long>(packages, i).Where(c => c.Sum() == groupMass).ToArray();

                if (groups.Length > 0)
                    return groups.Select(g => g.Aggregate((long) 1, (acc, val) => acc * val)).Min().ToString();
            }

            return "";
        }
    }
}