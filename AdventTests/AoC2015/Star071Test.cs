using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star071Test : SolutionTest<Star071>
    {
        [TestCase("d", "72")]
        [TestCase("e", "507")]
        [TestCase("f", "492")]
        [TestCase("g", "114")]
        [TestCase("h", "65412")]
        [TestCase("i", "65079")]
        [TestCase("x", "123")]
        [TestCase("y", "456")]
        public void SampleTests(string wire, string expected)
        {
            var input = @"123 -> x
456 -> y
x AND y -> d
x OR y -> e
x LSHIFT 2 -> f
y RSHIFT 2 -> g
NOT x -> h
NOT y -> i";

            Assert.AreEqual(expected, Star071.EvaluateWire(input, wire).ToString());
        }
    }
}