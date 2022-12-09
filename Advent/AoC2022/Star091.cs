using System;
using System.Collections.Generic;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 9, 1)]
    public class Star091 : Solution<int>
    {
        public struct Movement
        {
            public (int X, int Y) Direction;
            public int Distance;
        }
        
        public struct Position
        {
            public int X;
            public int Y;

            public void Add((int X, int Y) offset)
            {
                X += offset.X;
                Y += offset.Y;
            }
        }
        
        public override int Run(string input)
        {
            var visited = new HashSet<Position>();

            var head = new Position();
            var tail = new Position();

            foreach (var movement in Utility.InputTo(LineToMovement, input))
            {
                for (int i = 0; i < movement.Distance; i++)
                {
                    var oldHead = head;
                    head.Add(movement.Direction);

                    if (Math.Abs(head.X - tail.X) > 1 || Math.Abs(head.Y - tail.Y) > 1)
                        tail = oldHead;

                    visited.Add(tail);
                }
            }

            return visited.Count;
        }

        public static Movement LineToMovement(string l)
        {
            var splits = l.Split(' ');
            return new Movement
            {
                Direction = splits[0] switch
                {
                    "U" => (0, 1),
                    "L" => (-1, 0),
                    "D" => (0, -1),
                    "R" => (1, 0),
                    _ => throw new ArgumentException()
                },
                Distance = int.Parse(splits[1])
            };
        }
    }
}