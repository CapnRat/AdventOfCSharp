using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 01, 01)]
    public class Star011 : Solution<int>
    {
        public override int Run(string input)
        {
            int max = 0;
            int current = 0;
            foreach (var line in Utility.InputToLines(input))
            {
                if (string.IsNullOrEmpty(line))
                {
                    if (current > max)
                        max = current;
                    current = 0;
                    continue;
                }

                var amount = int.Parse(line);
                current += amount;
            }

            return max;
        }
    }
}