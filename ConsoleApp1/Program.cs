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
           Неявные преобразования
            sbyte → short, int, long, float, double, decimal, nint
            byte → short, ushort, int, uint, long, ulong, float, double, decimal, nint, nuint
            short → int, long, float, double, decimal, nint
            ushort → int, uint, long, ulong, float, double, decimal, nint, nuint
            int → long, float, double, decimal, nint
            uint → long, ulong, float, double, decimal, nuint
            long → float, double, decimal
            ulong → float, double, decimal
            char → ushort, int, uint, long, ulong, float, double, decimal
            float → double
           Явные преобразования
            sbyte → byte, ushort, uint, ulong, char, nuint
            byte → sbyte, char, nint
            short → sbyte, byte, ushort, uint, ulong, char, nint, nuint
            ushort → sbyte, byte, short, nint, char
            int → sbyte, byte, short, ushort, uint, ulong, char, nuint
            uint → sbyte, byte, short, ushort, int, nint, char
            long → sbyte, byte, short, ushort, int, uint, ulong, nint, char, nuint
            ulong → sbyte, byte, short, ushort, int, uint, long, nint, char, nuint
            float → sbyte, byte, short, ushort, int, uint, long, ulong, char, nint, nuint
            double → sbyte, byte, short, ushort, int, uint, long, ulong, float, char, nint, nuint
            decimal → sbyte, byte, short, ushort, int, uint, long, ulong, float, double, char, nint, nuint
            char → sbyte, byte, short, ushort, int, uint, long, ulong, nint, nuint
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
            if (obj is int val) Console.WriteLine(val);
            
            string str2 = obj as string;
            if (str2 == null) Console.WriteLine("1Преобразование не удалось");
            
            // Преобразование с помощью convert и parse
            int num = Convert.ToInt32(str2);
            try
            {
                num = int.Parse(str2);
            }
            catch
            {
                Console.WriteLine("2Преобразование не удалось");
            }
            if (!int.TryParse("123", out num))
            {
                Console.WriteLine("3Перевод не удался");
            }
        }
    }
}