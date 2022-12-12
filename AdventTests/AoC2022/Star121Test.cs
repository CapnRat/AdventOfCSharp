using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star121Test : SolutionTest<Star121>
    {
        [TestCase(@"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi", 31)]
        public void ExampleTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}