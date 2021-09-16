using System;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15, 1, 2)]
    public class Star012 : Solution
    {
        public override string Run(string input)
        {
            var floor = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(') floor++;
                else floor--;

                if (floor == -1) return (i + 1).ToString();
            }

            throw new IndexOutOfRangeException();
        }
    }
}