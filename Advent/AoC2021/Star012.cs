using System.Linq;
using Advent.Common;

namespace Advent.AoC2021
{
    [Solution(21, 1,2)]
    public class Star012 : Solution<int>
    {
        public override int Run(string input)
        {
            var depths = Utility.InputTo(int.Parse, input).ToArray();
            var count = 0;
            var last = int.MaxValue;
            for (int i = 0; i < depths.Length - 2; i++)
            {
                var window = depths[i..(i + 3)].Sum();
                if (window > last)
                    count++;
                last = window;
            }

            return count;
        }
    }
}