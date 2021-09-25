using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,20,2)]
    public class Star202 : Solution
    {
        public override string Run(string input)
        {
            int target = int.Parse(input);
            var presents = new int[target / 11];
            for (int elf = 1; elf < presents.Length; elf++)
            {
                for (int house = elf, i = 0; house < presents.Length && i < 50; house += elf, i++)
                {
                    presents[house] += elf * 11;
                }
            }

            for (var house = 1; house < presents.Length; house++)
            {
                if (presents[house] >= target)
                    return house.ToString();
            }

            return "";
        }

        public override string GetInput()
        {
            return "34000000";
        }
    }
}