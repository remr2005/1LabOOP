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
            // возвращаем пустую строку если ничего нет
            if (string.IsNullOrWhiteSpace(s)) return "";
            for (int i = 0;i<s.Length-1; i++)
            {
                // если следующий элемент блоьше текущего значит нам нужно его вычесть, иначе просто прибавить
                if (dict[s[i]] < dict[s[i+1]]) res-= dict[s[i]];
                else res += dict[s[i]];
            }
            // так как в цикле мы не доходим до последнего числа прибавляем его в конце последнее число в римских чслах всегда идет в плюс
            return (res + dict[s.Last()]).ToString();
        }
        public static string return_rome(string str)
        {
            StringBuilder res = new StringBuilder();
            if (string.IsNullOrWhiteSpace(str)) return "";
            int s = Int32.Parse(str);
            var dict = new Dictionary<string, int>()
            {
                {"I", 1},
                { "IV", 4},
                { "V", 5},
                { "IX", 9},
                { "X", 10},
                { "XL", 40},
                { "L", 50},
                {"XC", 90},
                { "C", 100 },
                { "CD", 400 },
                {"D", 500 },
                {"CM", 900 },
                {"M", 1000 },
            };
            foreach (string i in dict.Keys.Reverse())
            {
                while (s >= dict[i])
                {
                    s -= dict[i];
                    res.Append(i);
                }
            }
            return res.ToString();
        }
    }
}
