using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 2, 2)]
    public class Star022 : Solution<int>
    {
        public override int Run(string input)
        {
            int score = 0;
            foreach (var line in Utility.InputToLines(input))
            {
                int opponentAction = line[0] - 'A';
                int strategy = line[2] - 'X';

                int choiceScore = (opponentAction + strategy) % 3;
                choiceScore = choiceScore == 0 ? 3 : choiceScore;
                score += (3 * strategy) + choiceScore;
            }

            return score;
        }
    }
}