using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,13,2)]
    public class Star132 : Solution
    {
        public override string Run(string input)
        {
            var (people, happiness) = Star131.ProcessInput(input);

            people.Add("Me");

            return Star131.GetBestValue(people, happiness).ToString();
        }
    }
}