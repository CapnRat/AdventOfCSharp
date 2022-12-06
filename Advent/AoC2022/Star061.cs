using System;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 6, 1)]
    public class Star061 : Solution<int>
    {
        public override int Run(string input)
        {
            for (int i = 4; i <= input.Length; i++)
            {
                if (input[(i - 4)..i].Distinct().Count() == 4)
                    return i;
            }

            throw new ApplicationException("Failed to find starting packet.");
        }
    }
}