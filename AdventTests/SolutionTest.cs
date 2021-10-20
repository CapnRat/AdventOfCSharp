using System;
using Advent.Common;
using NUnit.Framework;

namespace AdventTests
{
    public abstract class SolutionTest<T>
    {
        protected dynamic solution;
        
        [SetUp]
        public void Setup()
        {
            solution = Activator.CreateInstance<T>();
        }

        protected void Run(string input, dynamic expected)
        {
            Assert.AreEqual(expected, solution.Run(input));
        }
    }
}