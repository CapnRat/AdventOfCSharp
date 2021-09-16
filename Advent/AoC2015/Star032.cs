using System.Collections.Generic;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,3,2)]
    public class Star032 : Solution
    {
        public override string Run(string input)
        {
            var (xOdd, yOdd) = (0, 0);
            var (xEven, yEven) = (0, 0);

            var houses = new HashSet<(int, int)> {(0, 0)};
            for (var i = 0; i < input.Length; i++)
            {
                var dir = input[i];

                if (i % 2 == 0)
                {
                    (xEven, yEven) = Move(dir, xEven, yEven);
                    houses.Add((xEven, yEven));
                }
                else
                {
                    (xOdd, yOdd) = Move(dir, xOdd, yOdd);
                    houses.Add((xOdd, yOdd));
                }
            }

            return houses.Count.ToString();
        }

        private (int, int) Move(char dir, int x, int y)
        {
            switch (dir)
            {
                case '^': y++;
                    break;
                case 'v': y--;
                    break;
                case '>': x++;
                    break;
                case '<': x--;
                    break;
            }

            return (x, y);
        }
    }
}