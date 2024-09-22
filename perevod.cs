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
            for (int i = 0; i < s.Length - 1; i++)
            {
                // если следующий элемент блоьше текущего значит нам нужно его вычесть, иначе просто прибавить
                if (dict[s[i]] < dict[s[i + 1]]) res -= dict[s[i]];
                else res += dict[s[i]];
            }
            // так как в цикле мы не доходим до последнего числа прибавляем его в конце последнее число в римских чслах всегда идет в плюс
            return (res + dict[s.Last()]).ToString();
        }
        public static string return_rome(string str)
        {
            StringBuilder res = new StringBuilder();
            //  если сторка пуста, то вернуть ""
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
            // пройдя по всем ключам
            foreach (string i in dict.Keys.Reverse())
            {
                // если при вычитании число остается в множестве натуральных чисел
                while (s >= dict[i])
                {
                    // то добавляем ключ в строку
                    s -= dict[i];
                    res.Append(i);
                }
            }
            return res.ToString();
        }
        // перевод из десятичной в любую другую
        public static string from_tenth_to(int a, int b)
        {
            // если введено неверное основание(меньше 2 или больше 16, то возвращаем "")
            if (b > 16 || b < 2) return "";
            var dict = new Dictionary<int, string>()
            {
                {0,"0"},
                {1, "1"},
                {2, "2"},
                {3, "3"},
                {4, "4"},
                {5, "5"},
                {6, "6"},
                {7, "7"},
                {8, "8"},
                {9,"9"},
                {10, "A"},
                {11, "B"},
                {12,"C"},
                {13,"D"},
                {14,"E"},
                {15,"F"},
            };
            StringBuilder res = new StringBuilder();
            while (a > 0)
            {
                // добавляем остаток от деления на основание системы счисления
                res.Insert(0, dict[a % b]);
                // делим число на основание
                a /= b;
            }
            return res.ToString();
        }
        // Мой корень
        public static decimal my_sqrt(decimal a, decimal t)
        {
            if (a == 0) return 0;
            // Приближение
            int n = (int)Math.Floor(Math.Log2((double)a));
            decimal a_ = a / (decimal)Math.Pow(2, 2 * n); // Вычисляем a
            decimal guess = (0.5m + 0.5m * a_) * (decimal)Math.Pow(2, n);
            // Основной цикл
            while (Math.Abs(((a / guess) + guess) / 2 - guess) > t)
            {
                guess = ((a / guess) + guess) / 2;
            }
            return guess;
        }
    }
}
