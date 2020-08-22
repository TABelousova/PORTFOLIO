using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._3
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
        /// Метод для вывода данных
        /// </summary>
        public static void Print(string text)
        {
            Console.WriteLine(text);
        }
        /// <summary>
        /// метод отсеивания повторяющихся символов
        /// </summary>
        /// <param name="text"></param>
        public static void Lit(string text)
        {
            char[] lit = text.ToCharArray();
            //text = new string(text.Distinct().ToArray());//нашел такой метод, но он удалет все повторяющиеся элементы массива
            //Console.WriteLine(text);
            for (int i = 0; i < lit.Length - 1; i++)
            {
                if (lit[i] == lit[i + 1]) { }
                else { Console.Write(lit[i]); }
            }

        }
        static void Main(string[] args)
        {
            Print("Введите фразу или предложение:");
            string text = Console.ReadLine();
            Lit(text);
            Console.ReadKey();
            Delay();
        }
    }
}
