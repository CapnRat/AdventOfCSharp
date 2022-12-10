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
            if (expected is string)
                expected = (expected as string).Replace("\r", "");

            var result = solution.Run(input);
            if (result is string)
                result = (result as string).Replace("\r", "");
            
            Assert.AreEqual(expected, result);
        }
    }
}