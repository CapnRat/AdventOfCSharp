using System.Collections.Generic;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,10,2)]
    public class Star102 : Solution
    {
        public override string Run(string input)
        {
            var result = input.Select(c => int.Parse(c.ToString())).ToList();
            for (int i = 0; i < 50; i++)
            {
                result = RunIteration(result);
            }
            return result.Count.ToString();
        }

        public static List<int> RunIteration(List<int> input)
        {
            var result = new List<int>();
            var number = input[0];
            var count = 0;
            for (int i = 0; i < input.Count(); i++)
            {
                if (input[i] != number)
                {
                    result.Add(count);
                    result.Add(number);
                    number = input[i];
                    count = 0;
                }
                
                count++;
            }
            result.Add(count);
            result.Add(number);
            return result;
        }

        public override string GetInput()
        {
            return "1113222113";
        }
    }
}