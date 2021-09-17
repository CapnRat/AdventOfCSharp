using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,6,1)]
    public class Star061 : Solution
    {
        public enum State
        {
            On,
            Off,
            Toggle
        }

        public struct Construction
        {
            public State State;
            public (int, int) Start;
            public (int, int) End;

            public override string ToString()
            {
                return $"{State} {Start} {End}";
            }
        }

        private readonly BitArray _data = new(1000*1000);
        public override string Run(string input)
        {
            foreach (var line in Utility.InputToLines(input))
            {
                RunConstruction(ParseConstruction(line));
            }

            return _data.Cast<bool>().Count(b => b).ToString();
        }

        private void RunConstruction(Construction construction)
        {
            for (var x = construction.Start.Item1; x <= construction.End.Item1; x++)
            {
                for (var y = construction.Start.Item2; y <= construction.End.Item2; y++)
                {
                    var index = x * 1000 + y;
                    switch (construction.State)
                    {
                        case State.On:
                            _data[index] = true;
                            break;
                        case State.Off:
                            _data[index] = false;
                            break;
                        case State.Toggle:
                            _data[index] = !_data[index];
                            break;
                    }
                }
            }
        }

        public static Construction ParseConstruction(string line)
        {
            var match = Regex.Match(line, @"^([a-z\s]*) (\d+),(\d+) through (\d+),(\d+)$");
            var state = match.Groups[1].Value switch
            {
                "turn on" => State.On,
                "turn off" => State.Off,
                "toggle" => State.Toggle,
                _ => throw new ArgumentOutOfRangeException()
            };

            var coords = match.Groups.Cast<Group>().Skip(2).Select(g => int.Parse(g.Value)).ToArray();

            return new Construction {State = state, Start = (coords[0], coords[1]), End = (coords[2], coords[3])};
        }
    }
}