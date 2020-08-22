using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._4
{
    class Program
    {
        /// <summary>
        /// метод паузы
        /// </summary>
        public static void Delay()
        {
            Console.WriteLine("Для продолжения нажмите любую клавишу");
            Console.ReadKey();
        }
        /// <summary>
        /// Метод вывода текста
        /// </summary>
        /// <param name="text"></param>
        public static void Print(string text)
        {
            Console.WriteLine(text);
        }
        /// <summary>
        /// Проверка на арифметическую и геометрическую прогрессию
        /// </summary>
        /// <param name="Num1"></param>
        /// <param name="Num2"></param>
        /// <param name="Num3"></param>
        /// <param name="Num4"></param>
        public static void Analiz(int Num)
        {
            int[] Matrix = new int[Num];
            int[] D = new int[Num-1];
            int[] Q = new int[Num-1];
            Random Rand = new Random();
            int countD = 0;
            int countQ = 0;
            for(int i=0; i< Num; i++)
            {
                Matrix[i] = Rand.Next(1, 100);
            }
            for(int i=0; i<Num-1; i++)
            {
                D[i] = Matrix[i + 1] - Matrix[i];
                Q[i] = Matrix[i + 1] / Matrix[i];
            }
            for(int i =0; i<Num-2; i++)
            {
                if(D[i] == D[i+1])
                { countD++;}
                if(Q[i]==Q[i+1])
                { countQ++; }
            }
            if(countD == Num-1)
            { Console.WriteLine("Прогрессия арифметическая.");}
            else { Console.WriteLine("Прогрессия не арифметическая.");}
            if (countQ == Num - 1)
            { Console.WriteLine("Прогрессия геометрическая.");}
            else { Console.WriteLine("Прогрессия не геометрическая.");}
        }
       
        static void Main(string[] args)
        {
            int Num;
            Print("Num = ?");
            Num = int.Parse(Console.ReadLine());
            Analiz(Num);
            Delay();
        }

    }
}
