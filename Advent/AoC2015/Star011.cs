using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15, 1, 1)]
    public class Star011 : Solution
    {
        public override string Run(string input)
        {
            var floor = 0;
            foreach (var c in input)
            {
                if (c == '(') floor++;
                else floor--;
            }

            return floor.ToString();
        }
    }
}