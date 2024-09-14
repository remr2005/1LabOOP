using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1LabOOP
{
    class perevod
    {
        public static string remove_rome(string s)
        {
            int res = 0;
            var dict = new Dictionary<char, int>()
            {
                {'I', 1},
                { 'V', 5},
                { 'X', 10},
                { 'L', 50},
                { 'C', 100 },
                {'D', 500 },
                {'M', 1000 }
            };
            if (string.IsNullOrWhiteSpace(s)) return "";
            for (int i = 0;i<s.Length-1; i++)
            {
                if (dict[s[i]] < dict[s[i+1]]) res-= dict[s[i]];
                else res += dict[s[i]];
            }
            return (res + dict[s.Last()]).ToString();
        }
    }
}
