using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22,5,2)]
    public class Star052 : Solution<string>
    {
        public override string Run(string input)
        {
            return Star051.RunPuzzle(input, true);
        }
    }
}