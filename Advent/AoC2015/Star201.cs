using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,20,1)]
    public class Star201 : Solution
    {
        public override string Run(string input)
        {
            int target = int.Parse(input);
            var presents = new int[target / 10];
            for (int elf = 1; elf < presents.Length; elf++)
            {
                for (int house = elf; house < presents.Length; house += elf)
                {
                    presents[house] += elf * 10;
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