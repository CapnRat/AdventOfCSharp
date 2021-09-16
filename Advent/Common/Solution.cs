using System.IO;
using System.Linq;

namespace Advent.Common
{
    public abstract class Solution
    {
        public abstract string Run(string input);

        public virtual string GetInput()
        {
            var attr = GetType().GetCustomAttributes(typeof(SolutionAttribute), false).First() as SolutionAttribute;
            return File.ReadAllText($"Input/{attr?.Year}{attr?.Day}.txt");
        }
    }
}