using System;
using System.Collections.Generic;
using System.Linq;
using Advent.Common;

namespace Advent.AoC2022
{
    [Solution(22, 14, 1)]
    public class Star141 : Solution<int>
    {
        private static readonly (int X, int Y)[] FallTests = { (0, 1), (-1, 1), (1, 1) };
        public static readonly Position SandEmitPosition = (500, 0);

        public override int Run(string input)
        {
            var rocks = ConstructRockGrid(input, out var bounds);

            var sand = SimulateSand(ref bounds, rocks);

            PrintGrid(bounds, rocks, sand, SandEmitPosition);

            return sand.Count;
        }

        public static IReadOnlySet<Position> ConstructRockGrid(string input, out (Position TopLeft, Position BottomRight) bounds)
        {
            var rocks = new HashSet<Position>();

            bounds = (SandEmitPosition, SandEmitPosition);

            foreach (var line in Utility.InputToLines(input))
            {
                var positions = line.Split(" -> ").Select(s =>
                {
                    var posSplits = s.Split(',');
                    return new Position { X = int.Parse(posSplits[0]), Y = int.Parse(posSplits[1]) };
                }).ToArray();

                for (int p = 1; p < positions.Length; p++)
                {
                    var prev = positions[p - 1];
                    var curr = positions[p];

                    (int X, int Y) stepDirection = (Math.Sign(prev.X - curr.X), Math.Sign(prev.Y - curr.Y));

                    rocks.Add(curr);
                    UpdateBounds(ref bounds, curr);
                    while (curr != prev)
                    {
                        curr += stepDirection;
                        rocks.Add(curr);
                        UpdateBounds(ref bounds, curr);
                    }
                }
            }

            return rocks;
        }

        public static IReadOnlySet<Position> SimulateSand(ref (Position TopLeft, Position BottomRight) bounds, IReadOnlySet<Position> rocks, int? floor = null)
        {
            var sand = new HashSet<Position>();

            while (true)
            {
                var grain = SandEmitPosition;
                Position lastPos;
                do
                {
                    lastPos = grain;
                    foreach (var test in FallTests)
                    {
                        var testPosition = grain + test;
                        if (rocks.Contains(testPosition) || sand.Contains(testPosition)) continue;

                        if (floor != null && testPosition.Y >= floor) continue;

                        grain = testPosition;
                        break;
                    }

                    if (floor == null && grain.Y > bounds.BottomRight.Y)
                        return sand;
                } while (grain != lastPos);

                sand.Add(grain);
                UpdateBounds(ref bounds, grain);

                if (floor != null && grain == SandEmitPosition)
                    return sand;
            }
        }

        public static void PrintGrid((Position TopLeft, Position BottomRight) bounds, IReadOnlySet<Position> rocks, IReadOnlySet<Position> sand,
            Position sandEmitPosition, int? floor = null)
        {
            if (floor != null)
                UpdateBounds(ref bounds, (bounds.BottomRight.X, floor.Value));
            
            for (int y = bounds.TopLeft.Y; y <= bounds.BottomRight.Y; y++)
            {
                for (int x = bounds.TopLeft.X - 1; x <= bounds.BottomRight.X + 1; x++)
                {
                    Position pos = (x, y);
                    var character = rocks.Contains(pos) ? '#' : sand.Contains(pos) ? 'o' : '.';
                    character = sandEmitPosition == pos ? '+' : character;
                    character = floor == y ? '#' : character;
                    Console.Write(character);
                }

                Console.WriteLine();
            }
        }

        public static void UpdateBounds(ref (Position TopLeft, Position BottomRight) bounds, Position curr)
        {
            bounds.TopLeft.X = Math.Min(bounds.TopLeft.X, curr.X);
            bounds.TopLeft.Y = Math.Min(bounds.TopLeft.Y, curr.Y);
            bounds.BottomRight.X = Math.Max(bounds.BottomRight.X, curr.X);
            bounds.BottomRight.Y = Math.Max(bounds.BottomRight.Y, curr.Y);
        }
    }
}