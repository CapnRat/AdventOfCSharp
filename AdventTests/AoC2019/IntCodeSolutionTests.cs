using System;
using Advent.AoC2019;
using Advent.Common;
using NUnit.Framework;

namespace AdventTests.AoC2019
{
    public class IntCodeSolutionTests
    {
        [TestCase(typeof(Star021), 4945026)]
        [TestCase(typeof(Star022), 5296)]
        [TestCase(typeof(Star051), 3122865)]
        [TestCase(typeof(Star052), 773660)]
        public void SolutionTests(Type solutionType, int expected)
        {
            dynamic solution = Activator.CreateInstance(solutionType);
            dynamic result = solution.Run(solution.GetInput());
            
            Assert.AreEqual(expected, result);
        }
    }
}