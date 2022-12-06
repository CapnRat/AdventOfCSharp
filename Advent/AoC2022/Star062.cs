using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 6, 2)]
    public class Star062 : Solution<int>
    {
        public override int Run(string input)
        {
            return Star061.DetectStart(input, 14);
        }
    }
}