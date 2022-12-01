using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star011Test : SolutionTest<Star011>
    {
        [TestCase(@"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000", 24000)]
        public void ExampleTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}