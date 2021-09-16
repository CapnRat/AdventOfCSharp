using System;
using System.Linq;
using System.Reflection;
using Advent.Common;

namespace Advent
{
    class Runner
    {
        static void Main(string[] args)
        {
            var solutions = Assembly.GetCallingAssembly().GetTypes()
                .Where(t => t.GetCustomAttributes(typeof(SolutionAttribute), false).Any()
                )
                .ToDictionary(type => 
                    EncodeIndex(type.GetCustomAttributes(typeof(SolutionAttribute), false)
                    .First() as SolutionAttribute)
                );

            var index = 0;
            if (args.Length > 0)
                index = int.Parse(args[0]);
            else
            {
                Console.Write("Solution: ");
                index = int.Parse(Console.ReadLine());
            }

            var solution = Activator.CreateInstance(solutions[index]) as Solution;
            var result = solution?.Run(solution.GetInput());

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
    }
}