using System.Collections.Generic;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,3,1)]
    public class Star031 : Solution
    {
        public override string Run(string input)
        {
            var (x, y) = (0, 0);

            var houses = new HashSet<(int, int)> {(x, y)};
            foreach (var dir in input)
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
                houses.Add((x, y));
            }
            
            return houses.Count.ToString();
        }
    }
}