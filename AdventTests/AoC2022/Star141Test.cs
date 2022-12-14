using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star141Test : SolutionTest<Star141>
    {
        [TestCase(@"498,4 -> 498,6 -> 496,6
503,4 -> 502,4 -> 502,9 -> 494,9", 24)]
        public void ExampleTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}