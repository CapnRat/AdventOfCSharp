using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star082Test : SolutionTest<Star082>
    {
        [TestCase("\"\"\n\"abc\"\n\"aaa\\\"aaa\"\n\"\\x27\"", "19")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}