using System;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2021
{
    [Solution(21, 3, 2)]
    public class Star032 : Solution<int>
    {
        public override int Run(string input)
        {
            var lines = Utility.InputToLines(input).ToArray();
            var width = lines[0].Length;
            
            var o2Candidates = lines;
            var co2Candidates = lines;
            for (int i = 0; i < width; i++)
            {
                var (gamma, _) = Star031.GetGammaEpsilon(o2Candidates);
                var (_, epsilon) = Star031.GetGammaEpsilon(co2Candidates);

                GetCandidates(gamma, width, i, ref o2Candidates);
                GetCandidates(epsilon, width, i, ref co2Candidates);
            }

            var o2 = Convert.ToInt32(o2Candidates[0], 2);
            var co2 = Convert.ToInt32(co2Candidates[0], 2);
            
            return o2 * co2;
        }

        private static void GetCandidates(int referenceValue, int length, int position, ref string[] o2Candidates)
        {
            if (o2Candidates.Length == 1) return;
            
            var bit = (referenceValue >> length - 1 - position) % 2;
            o2Candidates = o2Candidates.Where(c => c[position] - 48 == bit).ToArray();
        }
    }
}