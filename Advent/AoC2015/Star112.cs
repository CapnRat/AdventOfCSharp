using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,11,2)]
    public class Star112 : Solution
    {
        public override string Run(string input)
        {
            return new string(Star111.GetNextPassword(Star111.GetNextPassword(input.ToCharArray())));
        }

        public override string GetInput()
        {
            return "hepxcrrq";
        }
    }
}