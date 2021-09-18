using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,14,2)]
    public class Star142 : Solution
    {
        public override string Run(string input)
        {
            return RunWithDuration(input, 2503);
        }

        public static string RunWithDuration(string input, int duration)
        {
            var speeds = Utility.InputToLines(input).Select(Star141.ParseLineSpeed).ToArray();
            var points = new int[speeds.Length];
            var distances = new int[speeds.Length];
            for (int i = 1; i <= duration; i++)
            {
                int furthest = 0;
                for (int r = 0; r < speeds.Length; r++)
                {
                    var distance = Star141.SimulateReindeer(speeds[r], i);
                    if (distance > furthest)
                        furthest = distance;

                    distances[r] = distance;
                }

                for (int r = 0; r < speeds.Length; r++)
                {
                    if (distances[r] == furthest)
                        points[r]++;
                }
            }

            return points.Max().ToString();
        }
    }
}