using Advent.AoC2019;
using NUnit.Framework;

namespace AdventTests.AoC2019
{
    public class Star041Test
    {
        [TestCase(111111, true)]
        [TestCase(123445, true)]
        [TestCase(223450, false)]
        [TestCase(123789, false)]
        public void ExampleTests(int value, bool expected)
        {
            Assert.AreEqual(expected, Star041.IsValid(value));
        }
    }
}