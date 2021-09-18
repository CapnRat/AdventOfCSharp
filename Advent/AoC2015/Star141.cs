using System.Linq;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,14,1)]
    public class Star141 : Solution
    {
        public override string Run(string input)
        {
            return Utility.InputToLines(input).Max(l => SimulateReindeer(ParseLineSpeed(l), 2503)).ToString();
        }

        public static int SimulateReindeer((int speed, int stamina, int rest) reindeerSpeed, int duration)
        {
            var iterationTime = reindeerSpeed.stamina + reindeerSpeed.rest;
            var numIterations = duration / iterationTime;
            var remeindeer = duration % iterationTime;
            var distanceLastIteration = (remeindeer > reindeerSpeed.stamina ? reindeerSpeed.stamina : remeindeer) *
                                        reindeerSpeed.speed;

            return numIterations * reindeerSpeed.speed * reindeerSpeed.stamina + distanceLastIteration;
        }

        public static (int speed, int stamina, int rest) ParseLineSpeed(string line)
        {
            var splits = line.Split(" ");
            var speed = int.Parse(splits[3]);
            var stamina = int.Parse(splits[6]);
            var rest = int.Parse(splits[13]);

            return (speed, stamina, rest);
        }
    }
}