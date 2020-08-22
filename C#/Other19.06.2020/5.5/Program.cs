using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._5
{
    class Program
    {
        /// <summary>
        /// Метод для действий при нажатии клавиши
        /// </summary>
        public static void Delay()
        {
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey();
        }
        /// <summary>
        /// функция аккермана
        /// </summary>
        public static int Akk(int n, int m)
        {
            if (m == 0)
            {
                return n + 1;
            }
            else if (n == 0)
            {
                return Akk(m - 1, 1);
            }
            else
            {
                return Akk(m - 1, Akk(m, n - 1));
            }
        }
        /// <summary>
        /// Метод для вывода данных
        /// </summary>
        /// <param name="text"></param>
        public static void Print(string text)
        {
            Console.WriteLine(text);
        }
        static void Main(string[] args)
        {
            int n, m;
            Print("Введите n и m");
            n = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());
            Akk(n, m);
            Delay();
        }
    }
}
