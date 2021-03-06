using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star022Test : SolutionTest<Star022>
    {
        [TestCase("2x3x4", "34")]
        [TestCase("1x1x10", "14")]
        [TestCase("2x3x4\n1x1x10", "48")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}