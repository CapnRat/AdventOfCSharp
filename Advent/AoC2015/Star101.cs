using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,10,1)]
    public class Star101 : Solution
    {
        public override string Run(string input)
        {
            for (int i = 0; i < 40; i++)
            {
                input = RunIteration(input);
            }
            return input.Length.ToString();
        }

        public static string RunIteration(string input)
        {
            var result = "";
            var number = input[0];
            var count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != number)
                {
                    result += $"{count}{number}";
                    number = input[i];
                    count = 0;
                }
                
                count++;
            }
            result += $"{count}{number}";
            return result;
        }

        public override string GetInput()
        {
            return "1113222113";
        }
    }
}