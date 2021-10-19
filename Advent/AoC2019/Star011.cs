using System.Linq;
using Advent.Common;

namespace Advent.AoC2019
{
    [Solution(19,1,1)]
    public class Star011 : Solution
    {
        public override string Run(string input)
        {
            return Utility.InputTo(int.Parse, input).Select(CalcFuel).Sum().ToString();
        }

        public static int CalcFuel(int mass)
        {
            return mass / 3 - 2;
        }
    }
}