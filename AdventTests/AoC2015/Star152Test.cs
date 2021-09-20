using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star152Test : SolutionTest<Star152>
    {
        [TestCase(@"Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8
Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3", "57600000")]
        public void SampleTests(string input, string expected)
        {
            Run(input, expected);
        }
    }
}