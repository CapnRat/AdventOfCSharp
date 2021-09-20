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
            var ingredients = Utility.InputToLines(input).Select(l =>l.Split(" ").Select(s => s.Trim(':').Trim(',')).Where(s => int.TryParse(s, out _)).Select(s => int.Parse(s)).ToArray()).ToArray();

            return GetCookies(ingredients).Max().ToString();
        }

        private IEnumerable<int> GetCookies(int[][] ingredients)
        {
            var cookies = new List<int>();
            var amounts = new int[ingredients.Length];
            
            Assemble(0, 100, cookies, ingredients, ref amounts);

            return cookies;
        }

        private void Assemble(int ingredient, int remaining, List<int> cookies, int[][] ingredients, ref int[] amounts)
        {
            if (ingredient == ingredients.Length - 1)
            {
                amounts[ingredient] = remaining;
                
                var values = new int[ingredients[0].Length - 1];
                for (var i = 0; i < ingredients.Length; i++)
                {
                    for (var p = 0; p < ingredients[i].Length - 1; p++)  // ignore calories
                    {
                        values[p] += ingredients[i][p] * amounts[i];
                    }
                }

                cookies.Add(values.Aggregate((total, next) => total * (next < 0 ? 0 : next)));

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