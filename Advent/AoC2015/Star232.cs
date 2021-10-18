using System;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,23,2)]
    public class Star232 : Solution
    {
        public override string Run(string input)
        {
            return Star231.RunProgram(input, new uint[]{1, 0});
        }
    }
}