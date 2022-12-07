using System.IO;
using System.Linq;
using JetBrains.Annotations;

namespace Advent.Common
{
    public abstract class Solution : Solution<string> {}

    [UsedImplicitly(ImplicitUseTargetFlags.WithInheritors)]
    public abstract class Solution<T>
    {
        public abstract T Run(string input);
        
        public virtual string GetInput()
        {
            var attr = GetType().GetCustomAttributes(typeof(SolutionAttribute), false).First() as SolutionAttribute;
            return File.ReadAllText($"Input/{attr?.Year}{attr?.Day}.txt");
        }
    }
}