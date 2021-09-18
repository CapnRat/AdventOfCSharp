using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star141Test : SolutionTest<Star141>
    {
        [TestCase("Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.", 1120)]
        [TestCase("Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.", 1056)]
        public void SampleTests(string input, int expected)
        {
            Assert.AreEqual(expected, Star141.SimulateReindeer(Star141.ParseLineSpeed(input), 1000));
        }
    }
}