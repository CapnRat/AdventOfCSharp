using System;
using System.Linq;
using Advent.Common;
using Newtonsoft.Json.Linq;

namespace Advent.AoC2022
{
    [Solution(22, 13, 1)]
    public class Star131 : Solution<int>
    {
        public static dynamic JTokenToType(JToken token) => token switch
        {
            JArray array => array,
            JValue value => value,
            _ => throw new NotImplementedException()
        };
        
        public static int Compare(JArray left, JArray right)
        {
            var count = Math.Min(left.Count, right.Count);
            for (int i = 0; i < count; i++)
            {
                var result = Compare(JTokenToType(left[i]), JTokenToType(right[i]));
                if (result == 0)
                    continue;
                return result;
            }

            return left.Count.CompareTo(right.Count);
        }

        public static int Compare(JValue left, JValue right) => left.CompareTo(right);
        public static int Compare(JArray left, JValue right) => Compare(left, new JArray(right));
        public static int Compare(JValue left, JArray right) => Compare(new JArray(left), right);
        
        public override int Run(string input)
        {
            int orderedSum = 0;
            
            JArray left = null;
            int pair = 1;
            foreach (var data in Utility.InputToLines(input)
                         .Where(l => !string.IsNullOrEmpty(l))
                         .Select(JArray.Parse))
            {
                if (left == null)
                {
                    left = data;
                    continue;
                }
                
                if (Compare(left, data) <= 0)
                    orderedSum += pair;

                left = null;
                pair++;
            }

            return orderedSum;
        }
    }
}