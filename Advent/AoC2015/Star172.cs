using System.Linq;
using Advent.Common;
using Combinatorics.Collections;

namespace Advent.AoC2015
{
    [Solution(15,17,2)]
    public class Star172 : Solution
    {
        public override string Run(string input)
        {
            return RunWithLiters(Utility.InputTo(int.Parse, input).ToArray(), 150).ToString();
        }

        public int RunWithLiters(int[] containers, int liters)
        {
            for (int i = 1; i <= containers.Length; i++)
            {
                var count = new Combinations<int>(containers, i).Count(l => l.Sum() == liters);
                if (count > 0)
                    return count;
            }

            return 0;
        }
    }
}