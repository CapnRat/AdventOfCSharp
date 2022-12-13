using System;
using Advent.Common;
using Newtonsoft.Json.Linq;

namespace Advent.AoC2022
{
    [Solution(22, 13, 1)]
    public class Star131 : Solution<int>
    {
        public dynamic JTokenToType(JToken token)
        {
            switch (token)
            {
                case JArray array:
                    return array;
                case JValue value:
                    return value;
                default:
                    throw new NotImplementedException();
            }
        }
        
        public int Compare(JArray left, JArray right)
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

        public int Compare(JValue left, JValue right)
        {
            return left.CompareTo(right);
        }

        public int Compare(JArray left, JValue right)
        {
            return Compare(left, new JArray(right));
        }

        public int Compare(JValue left, JArray right)
        {
            return Compare(new JArray(left), right);
        }
        
        public override int Run(string input)
        {
            int orderedSum = 0;
            
            dynamic left = null;
            int pair = 1;
            foreach (var line in Utility.InputToLines(input))
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                
                dynamic data = JArray.Parse(line);

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