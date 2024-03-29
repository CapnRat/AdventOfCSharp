﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Advent.Common;

namespace Advent
{
    static class Runner
    {
        static void Main(string[] args)
        {
            var solutions = Assembly.GetCallingAssembly().GetTypes()
                .Where(t => t.GetCustomAttributes(typeof(SolutionAttribute), false).Any())
                .ToDictionary(type => 
                    EncodeIndex(type.GetCustomAttributes(typeof(SolutionAttribute), false)
                    .First() as SolutionAttribute)
                );

            var index = args.Length > 0 ? int.Parse(args[0]) : solutions.Keys.Max();
            dynamic solution = Activator.CreateInstance(solutions[index]);
            var (year, day, star) = DecodeIndex(index);
            Console.WriteLine($"Running Solution: Year {year}, Day {day}, Star {star}");

            var input = solution?.GetInput();
            var sw = new Stopwatch();
            sw.Start();
            var result = solution?.Run(input).ToString();
            sw.Stop();
            Console.WriteLine("Time {0}ms", sw.ElapsedMilliseconds);
            Console.WriteLine(result);
        }

        static int EncodeIndex(SolutionAttribute attr)
        {
            return EncodeIndex(attr.Year, attr.Day, attr.Star);
        }

        static int EncodeIndex(int year, int day, int star)
        {
            // Format: YYDDS
            return year * 1000 + day * 10 + star;
        }

        static (int, int, int) DecodeIndex(int index)
        {
            return (index / 1000, index % 1000 / 10, index % 1000 % 10);
        }
    }
}