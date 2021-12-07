using Advent.Common;

namespace Advent.AoC2021
{
    [Solution(21, 2, 1)]
    public class Star021 : Solution<int>
    {
        public override int Run(string input)
        {
            var position = 0;
            var depth = 0;
            
            foreach (var command in Utility.InputToLines(input))
            {
                var splits = command.Split(' ');
                switch (splits[0])
                {
                    case "forward":
                        position += int.Parse(splits[1]);
                        break;
                    case "down":
                        depth += int.Parse(splits[1]);
                        break;
                    case "up":
                        depth -= int.Parse(splits[1]);
                        break;
                }
            }

            return position * depth;
        }
    }
}