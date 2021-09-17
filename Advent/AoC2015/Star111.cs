using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,11,1)]
    public class Star111 : Solution
    {
        public override string Run(string input)
        {
            return new string(GetNextPassword(input.ToArray()));
        }

        public override string GetInput()
        {
            return "hepxcrrq";
        }

        public static char[] GetNextPassword(char[] candidate)
        {
            while (true)
            {
                candidate = IncrementDigit(candidate, candidate.Length - 1);
                if (IsValid(candidate)) return candidate;
            }
        }

        private static char[] IncrementDigit(char[] candidate, int digit)
        {
            if (++candidate[digit] <= 'z') return candidate;
            
            candidate[digit] = 'a';
            return IncrementDigit(candidate, digit - 1);

        }

        private static bool IsValid(char[] candidate)
        {
            var hasStraight = false;
            var firstDouble = -2;
            var hasDoubles = false;
            for (int i = 0; i < candidate.Length; i++)
            {
                var c = candidate[i];
                if (c is 'i' or 'o' or 'l') return false;

                if (!hasStraight && i + 2 < candidate.Length)
                {
                    hasStraight = c + 1 == candidate[i + 1] && c + 2 == candidate[i + 2];
                }

                if (!hasDoubles && i + 1 < candidate.Length)
                {
                    if (candidate[i + 1] == c && firstDouble + 1 != i)
                        if (firstDouble < 0)
                            firstDouble = i;
                        else
                            hasDoubles = true;
                }
            }

            return hasStraight && hasDoubles;
        }
    }
}