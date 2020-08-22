using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2
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
        /// метод нахождения самого большого и самого маленькогто слова
        /// </summary>
        /// <param name="text"></param>
        public static void Min_Text(string text)
        {
            char[] sign = {' ', '.', ',',};
            string[] words = text.Split(sign);
            string min_word = string.Empty;
            string max_word = string.Empty;
            int max = int.MaxValue;
            int min = int.MinValue;
            foreach (string word in words)
            {
                if(word.Length < max)
                {
                    max = word.Length;
                    min_word = word;
                }
                if(word.Length>min)
                {
                    min = word.Length;
                    max_word = word;
                }
            }
            Console.WriteLine("минимальное слово: " + min_word);
            Console.WriteLine("Максимальное слово: " + max_word);
        }
        static void Main(string[] args)
        {
            Print("Введите предложение:");
            string text = Console.ReadLine();
            Min_Text(text);
            Delay();
        }
    }
}
