using Advent.AoC2019;
using NUnit.Framework;

namespace AdventTests.AoC2019
{
    public class Star042Test
    {
        [TestCase(111111, false)]
        [TestCase(123445, true)]
        [TestCase(112233, true)]
        [TestCase(111122, true)]
        [TestCase(112222, true)]
        [TestCase(223450, false)]
        [TestCase(123789, false)]
        [TestCase(123444, false)]
        public void ExampleTests(int value, bool expected)
        {
            Assert.AreEqual(expected, Star042.IsValid(value));
        }
    }
}