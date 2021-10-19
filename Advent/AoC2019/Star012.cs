using System.Linq;
using Advent.Common;

namespace Advent.AoC2019
{
    [Solution(19,1,2)]
    public class Star012 : Solution<int>
    {
        public override int Run(string input)
        {
            return Utility.InputTo(int.Parse, input).Select(CalcFuel).Sum();
        }

        public static int CalcFuel(int mass)
        {
            var fuel = mass / 3 - 2;
            if (fuel > 0)
                return fuel + CalcFuel(fuel);
            return 0;
        }
    }
}