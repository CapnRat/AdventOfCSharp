using System.Collections.Generic;
using System.Linq;
using Advent.Common;
using Combinatorics.Collections;

namespace Advent.AoC2015
{
    [Solution(15,17,1)]
    public class Star171 : Solution
    {
        public override string Run(string input)
        {
            return RunWithLiters(Utility.InputTo(int.Parse, input).ToArray(), 150).ToString();
        }

        public int RunWithLiters(int[] containers, int liters)
        {
            var count = 0;
            for (int i = 1; i <= containers.Length; i++)
            {
                count += new Combinations<int>(containers, i).Count(l => l.Sum() == liters);
            }

            return count;
        }
    }
}