using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 2, 1)]
    public class Star021 : Solution<int>
    {
        public override int Run(string input)
        {
            int score = 0;

            const int asciiDiff = 'X' - 'A';
            
            foreach (var line in Utility.InputToLines(input))
            {
                int opponentAction = line[0] + asciiDiff;
                int strategyAction = line[2];

                if (opponentAction == strategyAction)
                    score += 3;
                else if (strategyAction - opponentAction == 1 || strategyAction - opponentAction == -2)
                    score += 6;

                score += strategyAction - 'X' + 1;
            }

            return score;
        }
    }
}