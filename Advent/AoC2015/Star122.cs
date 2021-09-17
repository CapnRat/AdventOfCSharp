using System;
using System.Linq;
using Advent.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Advent.AoC2015
{
    [Solution(15,12,2)]
    public class Star122 : Solution
    {
        public override string Run(string input)
        {
            return GetValue(JsonConvert.DeserializeObject(input)).ToString();
        }

        private long GetValue(object obj)
        {
            switch (obj)
            {
                case JValue jValue:
                    if (jValue.Type == JTokenType.Integer) return (long)jValue.Value;
                    return 0;
                case JArray jArray:
                    return jArray.Sum(GetValue);
                case JObject jObject:
                    return jObject.PropertyValues().Any(t =>
                        t is JValue {Type: JTokenType.String} jv && (string) jv.Value == "red")
                        ? 0
                        : jObject.PropertyValues().Sum(GetValue);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}