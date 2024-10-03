using System;
using System.Diagnostics.Metrics;

namespace laboratory_work1
{
    class Man
    {
        int age;
        public Man(int n)
        {
            age = n;
        }
        public static explicit operator Cvadrober(Man n) { return new Cvadrober(n.age); }
    }

    class Cvadrober
    {
        int iq = 0;
        public Cvadrober(int iq)
        {
            this.iq = iq;
        }
        public static implicit operator Man(Cvadrober n) { return new Man(n.iq);}
    }

    public class Program
    {
        static void Main()
        {
            /*
           Таблица неявных преобразований типов:

           sbyte   →   short, int, long, float, double, decimal или nint
           byte    →   short, ushort, int, uint, long, ulong, float, double, decimal, nint или nuint
           short   →   int, long, float, double или decimal либо nint
           ushort  →   int, uint, long, ulong, float, double или decimal, nint или nuint
           int     →   long, float, double или decimal, nint
           uint    →   long, ulong, float, double или decimal либо nuint
           long    →   float, double или decimal
           ulong   →   float, double или decimal
           float   →   double
           nint    →   long, float, double или decimal
           nuint   →   ulong, float, double или decimal

           Таблица явных преобразований типов:

           sbyte   →   byte, ushort, uint, ulong или nuint
           byte    →   sbyte
           short   →   sbyte, byte, ushort, uint, ulong или nuint
           ushort  →   sbyte, byte или short
           int     →   sbyte, byte, short, ushort, uint, ulong или nuint
           uint    →   sbyte, byte, short, ushort, int или nint
           long    →   sbyte, byte, short, ushort, int, uint, ulong, nint или nuint
           ulong   →   sbyte, byte, short, ushort, int, uint, long, nint или nuint
           float   →   sbyte, byte, short, ushort, int, uint, long, ulong, decimal, nint или nuint
           double  →   sbyte, byte, short, ushort, int, uint, long, ulong, float, decimal, nint или nuint
           decimal →   sbyte, byte, short, ushort, int, uint, long, ulong, float, double, nint или nuint
           nint    →   sbyte, byte, short, ushort, int, uint, ulong или nuint
           nuint   →   sbyte, byte, short, ushort, int, uint, long или nint
           */
            // Неявное преобразование простых типов
            char a = '1';
            int b = a;
            Console.WriteLine(b);
            // Неявное преобразование простых ссылочных типов
            string? str = null;
            object? obj = str;
            // Явное преобразование простых типов
            float c = (float)a;
            Console.WriteLine(c);
            // Явное преобразование ссылочных типов
            obj = (string)"Some text 2";
            //Безопастное приведение ссылочных типов 
            obj = 2414;
            if (obj is int val)
            {
                Console.WriteLine(val);
            }
            else
            {
                Console.WriteLine("приведение не безопастно");
            }
            string str2 = obj as string;
            if (str2 == null)
            {
                Console.WriteLine("Преобразование не вышло");
            }
            else
            {
                Console.WriteLine($"преобразование в строку удалось {str2}");
            }
            // Преобразование с помощью convert и parse
            int num = Convert.ToInt32(str2);
            try
            {
                num = int.Parse(str2);
            }
            catch
            {
                Console.WriteLine("Преобразование не удалось");
            }
            if (int.TryParse("123", out num))
            {
                Console.WriteLine("Перевод удался");
            }
            else { Console.WriteLine(num); }

        }
    }
}