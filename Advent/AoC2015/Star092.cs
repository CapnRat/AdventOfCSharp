using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,9,2)]
    public class Star092 : Solution
    {
        public override string Run(string input)
        {
            return Star091.GetRouteDistances(input).Max().ToString();
        }
    }
}