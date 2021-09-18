using Advent.AoC2015;
using NUnit.Framework;

namespace AdventTests.AoC2015
{
    public class Star142Test : SolutionTest<Star142>
    {
        [TestCase(@"Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.", "689")]
        public void SampleTests(string input, string expected)
        {
            Assert.AreEqual(expected, Star142.RunWithDuration(input, 1000));
        }
    }
}