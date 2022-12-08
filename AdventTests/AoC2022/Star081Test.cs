using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star081Test : SolutionTest<Star081>
    {
        [TestCase(@"30373
25512
65332
33549
35390", 21)]
        public void ExampleTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}