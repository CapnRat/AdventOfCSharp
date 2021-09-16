using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star012Test : SolutionTest<Star012>
    {
        [TestCase(")", "1")]
        [TestCase("()())", "5")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}