using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,15,1)]
    public class Star151 : Solution
    {
        public override string Run(string input)
        {
            var ingredients = GetIngredientsFromInput(input);

            return GetCookies(ingredients).Max(c => c.Item1).ToString();
        }

        public static int[][] GetIngredientsFromInput(string input)
        {
            var ingredients = Utility.InputToLines(input).Select(l =>
                l.Split(" ").Select(s => s.Trim(':').Trim(',')).Where(s => int.TryParse(s, out _)).Select(s => int.Parse(s))
                    .ToArray()).ToArray();
            return ingredients;
        }

        public static IEnumerable<(int, int)> GetCookies(int[][] ingredients)
        {
            var cookies = new List<(int, int)>();
            var amounts = new int[ingredients.Length];
            
            Assemble(0, 100, cookies, ingredients, ref amounts);

            return cookies;
        }

        private static void Assemble(int ingredient, int remaining, List<(int, int)> cookies, int[][] ingredients, ref int[] amounts)
        {
            if (ingredient == ingredients.Length - 1)
            {
                amounts[ingredient] = remaining;
                
                var values = new int[ingredients[0].Length - 1];
                var calories = 0;
                for (var i = 0; i < ingredients.Length; i++)
                {
                    for (var p = 0; p < ingredients[i].Length - 1; p++)  // ignore calories
                    {
                        values[p] += ingredients[i][p] * amounts[i];
                    }

                    calories += ingredients[i][values.Length] * amounts[i];
                }

                cookies.Add((values.Aggregate((total, next) => total * (next < 0 ? 0 : next)), calories));

                return;
            }
            
            for (int amount = 0; amount <= remaining; amount++)
            {
                amounts[ingredient] = amount;
                Assemble(ingredient + 1, remaining - amount, cookies, ingredients, ref amounts);
            }
        }
    }
}