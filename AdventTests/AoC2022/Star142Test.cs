using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star142Test : SolutionTest<Star142>
    {
        [TestCase(@"498,4 -> 498,6 -> 496,6
503,4 -> 502,4 -> 502,9 -> 494,9", 93)]
        public void ExampleTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}