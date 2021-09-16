using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star021Test : SolutionTest<Star021>
    {
        [TestCase("2x3x4", "58")]
        [TestCase("1x1x10", "43")]
        [TestCase("2x3x4\n1x1x10", "101")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}