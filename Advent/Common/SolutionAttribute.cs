using System;

namespace Advent.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SolutionAttribute : Attribute
    {
        public int Year { get; }
        public int Day { get; }
        public int Star { get; }

        public SolutionAttribute(int year, int day, int star)
        {
            this.Year = year;
            this.Day = day;
            this.Star = star;
        }
    }
}