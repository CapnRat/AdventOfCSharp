using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star061Test : SolutionTest<Star061>
    {
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void ExampleTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}