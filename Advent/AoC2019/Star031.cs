using System;
using System.Collections.Generic;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2019
{
    [Solution(19,3,1)]
    public class Star031 : Solution<int>
    {
        public override int Run(string input)
        {
            var grid = new HashSet<(int x, int y)>();
            var paths = Utility.InputToLines(input).Select(l => l.Split(',')).ToArray();

            var intersectionDistance = int.MaxValue;
            for (var pathIndex = 0; pathIndex < paths.Length; pathIndex++)
            {
                (int x, int y) = (0, 0);
                foreach (var direction in paths[pathIndex])
                {
                    var directionDistance = int.Parse(direction[1..]);
                    for (int i = 0; i < directionDistance; i++)
                    {
                        switch (direction[0])
                        {
                            case 'U':
                                y++;
                                break;
                            case 'D':
                                y--;
                                break;
                            case 'L':
                                x--;
                                break;
                            case 'R':
                                x++;
                                break;
                            default:
                                throw new ArgumentException();
                        }

                        if (pathIndex == 0)
                            grid.Add((x, y));
                        else if (grid.Contains((x, y)) && intersectionDistance > Math.Abs(x) + Math.Abs(y))
                            intersectionDistance = Math.Abs(x) + Math.Abs(y);
                    }
                }
            }

            return intersectionDistance;
        }
    }
}