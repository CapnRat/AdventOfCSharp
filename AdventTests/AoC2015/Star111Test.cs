using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star111Test : SolutionTest<Star111>
    {
        [TestCase("abcdfezz", "abcdffaa")]
        [TestCase("ghijklmn", "ghjaabcc")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}