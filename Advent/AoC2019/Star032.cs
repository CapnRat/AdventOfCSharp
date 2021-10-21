using System;
using System.Collections.Generic;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2019
{
    [Solution(19,3,2)]
    public class Star032 : Solution<int>
    {
        public override int Run(string input)
        {
            var grid = new Dictionary<(int x, int y), int>();
            var paths = Utility.InputToLines(input).Select(l => l.Split(',')).ToArray();

            var intersectionDistance = int.MaxValue;
            for (var pathIndex = 0; pathIndex < paths.Length; pathIndex++)
            {
                (int x, int y) = (0, 0);
                var distance = 0;
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
                        distance++;

                        if (pathIndex == 0)
                        {
                            if (!grid.ContainsKey((x, y)))
                                grid.Add((x, y), distance);
                        }
                        else if (grid.ContainsKey((x, y)) && intersectionDistance > distance + grid[(x,y)])
                            intersectionDistance = distance + grid[(x,y)];
                    }
                }
            }

            return intersectionDistance;
        }
    }
}