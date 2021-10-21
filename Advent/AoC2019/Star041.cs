using System;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2019
{
    [Solution(19,4,1)]
    public class Star041 : Solution<int>
    {
        public override int Run(string input)
        {
            var split = input.Split('-').Select(int.Parse).ToArray();
            (var lower, var upper) = (split[0], split[1]);

            return Enumerable.Range(lower, upper - lower).Count(IsValid);
        }

        private static readonly string[] DoubleDigits = {"00", "11", "22", "33", "44", "55", "66", "77", "88", "99"};

        public static bool IsValid(int value)
        {
            string sValue = value.ToString();
            
            if (!DoubleDigits.Any(d => sValue.Contains(d))) return false;

            var sorted = new char[6];
            sValue.ToArray().CopyTo(sorted, 0);
            Array.Sort(sorted);
            return sValue.SequenceEqual(sorted);
        }
    }
}