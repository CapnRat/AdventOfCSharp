using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star081Test : SolutionTest<Star081>
    {
        [TestCase("\"\"\n\"abc\"\n\"aaa\\\"aaa\"\n\"\\x27\"", "12")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}