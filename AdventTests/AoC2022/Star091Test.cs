using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star091Test : SolutionTest<Star091>
    {
        [TestCase(@"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2", 13)]
        public void ExampleTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}