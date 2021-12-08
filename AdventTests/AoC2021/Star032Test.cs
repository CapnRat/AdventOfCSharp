using Advent.AoC2021;
using NUnit.Framework;

namespace AdventTests.AoC2021
{
    public class Star032Test : SolutionTest<Star032>
    {
        [TestCase(@"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010", 230)]
        public void ExampleTest(string input, int expected)
        {
            Run(input, expected);
        }
    }
}