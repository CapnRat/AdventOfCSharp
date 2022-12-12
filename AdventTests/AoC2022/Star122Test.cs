using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star122Test : SolutionTest<Star122>
    {
        [TestCase(@"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi", 29)]
        public void ExampleTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}