using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,8,2)]
    public class Star082 : Solution
    {
        public override string Run(string input)
        {
            return Utility.InputToLines(input).Select(l => l.Count(c => c == '"' || c == '\\') + 2).Sum().ToString();
        }
    }
}