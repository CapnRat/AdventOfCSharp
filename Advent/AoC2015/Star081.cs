using System.Linq;
using System.Text.RegularExpressions;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,8,1)]
    public class Star081 : Solution
    {
        public override string Run(string input)
        {
            var accum = 0;
            var lines = Utility.InputToLines(input);
            foreach (var line in lines)
            {
                accum += line.Length - Regex.Unescape(line).Length + 2;
            }
            return accum.ToString();
        }
    }
}