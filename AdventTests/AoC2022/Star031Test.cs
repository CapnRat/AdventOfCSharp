using Advent.AoC2022;
using NUnit.Framework;

namespace AdventTests.AoC2022
{
    public class Star031Test : SolutionTest<Star031>
    {
        [TestCase(@"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw", 157)]
        public void ExampleTests(string input, int expected)
        {
            Run(input, expected);
        }
    }
}