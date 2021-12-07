using Advent.Common;

namespace Advent.AoC2021
{
    [Solution(21,2,2)]
    public class Star022 : Solution<int>
    {
        public override int Run(string input)
        {
            var position = 0;
            var depth = 0;
            var aim = 0;
            
            foreach (var command in Utility.InputToLines(input))
            {
                var splits = command.Split(' ');
                switch (splits[0])
                {
                    case "forward":
                        var val = int.Parse(splits[1]);
                        position += val;
                        depth += val * aim;
                        break;
                    case "down":
                        aim += int.Parse(splits[1]);
                        break;
                    case "up":
                        aim -= int.Parse(splits[1]);
                        break;
                }
            }

            return position * depth;
        }
    }
}