using Advent.AoC2019;
using NUnit.Framework;

namespace AdventTests.AoC2019
{
    public class Star012Test : SolutionTest<Star012>
    {
        [TestCase(14, 2)]
        [TestCase(1969, 966)]
        [TestCase(100756, 50346)]
        public void CalcTests(int mass, int expected)
        {
            Assert.AreEqual(expected, Star012.CalcFuel(mass));
        }
    }
}