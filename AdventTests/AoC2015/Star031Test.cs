using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star031Test : SolutionTest<Star031>
    {
        [TestCase(">", "2")]
        [TestCase("^>v<", "4")]
        [TestCase("^v^v^v^v^v", "2")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}