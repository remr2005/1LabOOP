using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace _1LabOOP
{
    class perevod
    {
        /// <summary>
        /// Переводит строку римских цифр в арабское число.
        /// </summary>
        /// <param name="s">Строка, содержащая римские цифры.</param>
        /// <returns>Арабское число в виде строки.</returns>
        public static string remove_rome(string s)
        {
            int res = 0; // Переменная для хранения результата
            // Словарь для сопоставления римских цифр с их значениями
            var dict = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
            // Возвращаем пустую строку, если входная строка пустая или состоит только из пробелов
            if (string.IsNullOrWhiteSpace(s)) return "";
            for (int i = 0; i < s.Length - 1; i++)
            {
                // Если следующий элемент больше текущего, вычитаем текущее значение
                if (dict[s[i]] < dict[s[i + 1]]) res -= dict[s[i]];
                else res += dict[s[i]]; // Иначе добавляем текущее значение
            }
            // Добавляем последнее значение, так как цикл не включает последний символ
            return (res + dict[s.Last()]).ToString();
        }

        /// <summary>
        /// Переводит арабское число в римские цифры.
        /// </summary>
        /// <param name="str">Строка, содержащая арабское число.</param>
        /// <returns>Римское число в виде строки.</returns>
        public static string return_rome(string str)
        {
            StringBuilder res = new StringBuilder(); // Для построения результата
            // Возвращаем пустую строку, если входная строка пустая или состоит только из пробелов
            if (string.IsNullOrWhiteSpace(str)) return "";
            int s = Int32.Parse(str); // Преобразуем строку в целое число
            // Словарь для сопоставления римских чисел с их значениями
            var dict = new Dictionary<string, int>()
            {
                {"I", 1},
                {"IV", 4},
                {"V", 5},
                {"IX", 9},
                {"X", 10},
                {"XL", 40},
                {"L", 50},
                {"XC", 90},
                {"C", 100},
                {"CD", 400},
                {"D", 500},
                {"CM", 900},
                {"M", 1000},
            };
            // Проходим по всем ключам в обратном порядке
            foreach (string i in dict.Keys.Reverse())
            {
                // Если при вычитании число остается больше или равно нулю
                while (s >= dict[i])
                {
                    // Добавляем ключ в результат и вычитаем его значение из s
                    s -= dict[i];
                    res.Append(i);
                }
            }
            return res.ToString(); // Возвращаем римское число
        }

        /// <summary>
        /// Переводит десятичное число в систему счисления с основанием от 2 до 16.
        /// </summary>
        /// <param name="a">Десятичное число.</param>
        /// <param name="b">Основание системы счисления.</param>
        /// <returns>Число в виде строки в новой системе счисления.</returns>
        public static string from_tenth_to(int a, int b)
        {
            // Проверка на корректность основания
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
            StringBuilder res = new StringBuilder(); // Для построения результата
            while (a > 0)
            {
                // Добавляем остаток от деления на основание в начало строки
                res.Insert(0, dict[a % b]);
                // Делим число на основание
                a /= b;
            }
            return res.ToString(); // Возвращаем результат
        }

        /// <summary>
        /// Вычисляет квадратный корень с заданной точностью.
        /// </summary>
        /// <param name="a">Число, из которого нужно извлечь корень.</param>
        /// <param name="t">Точность вычислений.</param>
        /// <returns>Квадратный корень числа.</returns>
        public static decimal my_sqrt(decimal a, decimal guess, decimal t=0)
        {
            if (a == 0) return 0; // Если число 0, возвращаем 0
            int i = 0;
            // Основной цикл для вычисления корня
            while (Math.Abs(((a / guess) + guess) / 2 - guess) > t)
            {
                i++;
                guess = ((a / guess) + guess) / 2; // Обновление предположения
            }
            return guess; // Возвращаем результат
        }
        
        // Вычисление приближения
        public static decimal approximation(decimal i)
        {
            int n = (int)Math.Log2((double)i);
            decimal a = i / (decimal)Math.Pow(2, 2 * n); // Вычисляем a
            return (0.5m + 0.5m * a) * (decimal)Math.Pow(2, n);
        }
        public static decimal iteration(decimal i, decimal a)
        {
            return ((a / i) + i) / 2;
        }
    }
}
