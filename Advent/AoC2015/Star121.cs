using System.Linq;
using System.Text.RegularExpressions;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,12,1)]
    public class Star121 : Solution
    {
        public override string Run(string input)
        {
            return Regex.Matches(input, @"(-?\d+)").Select(m => int.Parse(m.Groups[0].Value)).Sum().ToString();
        }
    }
}