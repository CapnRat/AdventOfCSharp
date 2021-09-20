using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,15,2)]
    public class Star152 : Solution
    {
        public override string Run(string input)
        {
            return Star151.GetCookies(Star151.GetIngredientsFromInput(input)).Where(c => c.Item2 == 500).Max(c => c.Item1).ToString();
        }
    }
}