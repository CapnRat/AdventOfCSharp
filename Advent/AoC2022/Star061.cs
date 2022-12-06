using System;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 6, 1)]
    public class Star061 : Solution<int>
    {
        public static int DetectStart(string data, int distinctCount)
        {
            for (int i = distinctCount; i <= data.Length; i++)
                if (data[(i - distinctCount)..i].Distinct().Count() == distinctCount)
                    return i;
            
            throw new ApplicationException("Failed to find starting packet.");
        }
        
        public override int Run(string input)
        {
            return DetectStart(input, 4);
        }
    }
}