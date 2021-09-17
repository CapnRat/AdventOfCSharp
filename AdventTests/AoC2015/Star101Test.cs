using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star101Test : SolutionTest<Star101>
    {
        [TestCase("1", "11")]
        [TestCase("11", "21")]
        [TestCase("21", "1211")]
        [TestCase("1211", "111221")]
        [TestCase("111221", "312211")]
        public void SampleTests(string input, string expected)
        {
            Assert.AreEqual(expected, Star101.RunIteration(input));
        }
    }
}