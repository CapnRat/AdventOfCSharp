using System.Collections.Generic;
using Advent.Common;

namespace Advent.AoC2021
{
    [Solution(21,3,1)]
    public class Star031 : Solution<int>
    {
        public override int Run(string input)
        {
            var (gamma, epsilon) = GetGammaEpsilon(Utility.InputToLines(input));
            return gamma * epsilon;
        }

        public static (int gamma, int epsilon) GetGammaEpsilon(IEnumerable<string> lines)
        {
            int[] bitCounts = null;
            foreach (var line in lines)
            {
                bitCounts ??= new int[line.Length];

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '1') bitCounts[i]++;
                    else bitCounts[i]--;
                }
            }

            var gamma = 0;
            var epsilon = 0;
            foreach (var count in bitCounts)
            {
                gamma <<= 1;
                epsilon <<= 1;
                if (count >= 0) gamma += 1;
                if (count < 0) epsilon += 1;
            }

            return (gamma, epsilon);
        }
    }
}