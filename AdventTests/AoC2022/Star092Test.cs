using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star092Test : SolutionTest<Star092>
    {
        [TestCase(@"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2", 1)]
        [TestCase(@"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20", 36)]
        public void ExampleTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}