using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent.Common
{
    public static class Utility
    {
        public static IEnumerable<string> InputToLines(string input)
        {
            using var reader = new StringReader(input);
            string line;
            while ((line = reader.ReadLine()) != null)
                yield return line;
        }

        public static int[] InputToIntCode(string input)
        {
            return input.Split(',').Select(int.Parse).ToArray();
        }

        public static IEnumerable<TResult> InputTo<TResult>(Func<string, TResult> func, string input)
        {
            return InputToLines(input).Select(func);
        }
    }

    public struct Position : IEquatable<Position>
    {
        public int X;
        public int Y;
        
        public bool Equals(Position other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Position other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !left.Equals(right);
        }
        
        public static Position operator +(Position left, Position right)
        {
            return new Position { X = left.X + right.X, Y = left.Y + right.Y };
        }
        
        public static Position operator -(Position left, Position right)
        {
            return new Position { X = left.X - right.X, Y = left.Y - right.Y };
        }

        public static implicit operator Position((int, int) tuple) =>
            new() { X = tuple.Item1, Y = tuple.Item2 };

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }

    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
}