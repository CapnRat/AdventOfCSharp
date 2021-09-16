using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star032Test : SolutionTest<Star032>
    {
        [TestCase("^v", "3")]
        [TestCase("^>v<", "3")]
        [TestCase("^v^v^v^v^v", "11")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}