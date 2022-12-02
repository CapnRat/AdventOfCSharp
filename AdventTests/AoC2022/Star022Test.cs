using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star022Test : SolutionTest<Star022>
    {
        [TestCase(@"A Y
B X
C Z", 12)]
        public void ExampleTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}