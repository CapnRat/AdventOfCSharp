using System;
using System.Collections.Generic;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2019
{
    [Solution(19,4,2)]
    public class Star042 : Solution<int>
    {
        public override int Run(string input)
        {
            var split = input.Split('-').Select(int.Parse).ToArray();
            (var lower, var upper) = (split[0], split[1]);

            return Enumerable.Range(lower, upper - lower).Count(IsValid);
        }

        public static bool IsValid(int value)
        {
            var sValue = value.ToString();
            return Star041.IsSorted(sValue)
                   && Enumerable.Range(48, 10).Select(i => sValue.Count(c => c == (char) i)).Any(i => i == 2);
        }
    }
}