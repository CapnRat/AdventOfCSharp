using System;
using System.IO;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15, 2,2)]
    public class Star022 : Solution
    {
        public override string Run(string input)
        {
            var result = Star021.RunWithAccum(input, (l, w, h) =>
            {
                return 2 * ((l + w + h) - new[] {l, w, h}.Max()) + (l * w * h);
            });
            return result.ToString();
        }
    }
}