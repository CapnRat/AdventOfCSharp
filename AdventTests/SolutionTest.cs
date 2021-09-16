using System;
using Advent.Common;
using NUnit.Framework;

namespace AdventTests
{
    public abstract class SolutionTest<T> where T : Solution
    {
        protected T solution;
        
        [SetUp]
        public void Setup()
        {
            solution = Activator.CreateInstance<T>();
        }

        public virtual void Run(string input, string expected)
        {
            Assert.AreEqual(expected, solution.Run(input));
        }
    }
}