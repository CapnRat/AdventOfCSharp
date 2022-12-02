using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star021Test : SolutionTest<Star021>
    {
        [TestCase(@"A Y
B X
C Z", 15)]
        public void ExampleTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}