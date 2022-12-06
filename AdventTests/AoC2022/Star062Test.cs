using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star062Test : SolutionTest<Star062>
    {
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void ExampleTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}