using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star042Test : SolutionTest<Star042>
    {
        [TestCase(@"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8", 4)]
        public void ExampleTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}