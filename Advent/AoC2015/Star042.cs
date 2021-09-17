using System.Security.Cryptography;
using System.Text;
using Advent.Common;

namespace Advent.AoC2015
{
    [Solution(15,4,2)]
    public class Star042 : Solution
    {
        public override string Run(string input)
        {
            using var md5 = MD5.Create();
            for(var i = 0;;i++)
            {
                var testString = input + i;
                var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(testString));
                if (hash[0] == 0 && hash[1] == 0 && hash[2] == 0) return i.ToString();
            }
        }

        public override string GetInput()
        {
            return "ckczppom";
        }
    }
}