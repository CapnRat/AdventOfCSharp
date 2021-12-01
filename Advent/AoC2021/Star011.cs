using System.Linq;
using Advent.Common;

namespace Advent.AoC2021
{
    [Solution(21, 1, 1)]
    public class Star011 : Solution<int>
    {
        public override int Run(string input)
        {
            var count = 0;
            Utility.InputTo(int.Parse, input).Aggregate((l, c) =>
            {
                if (c > l) count++;
                return c;
            });

            return count;
        }
    }
}