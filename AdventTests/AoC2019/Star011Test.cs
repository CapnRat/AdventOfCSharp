using Advent.AoC2019;
using NUnit.Framework;

namespace AdventTests.AoC2019
{
    public class Star011Test : SolutionTest<Star011>
    {
        [TestCase(12, 2)]
        [TestCase(14, 2)]
        [TestCase(1969, 654)]
        [TestCase(100756, 33583)]
        public void CalcTests(int mass, int expected)
        {
            Assert.AreEqual(expected, Star011.CalcFuel(mass));
        }
    }
}