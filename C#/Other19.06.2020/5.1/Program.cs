using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _5._1
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
        /// Метод умножения матрицы на число
        /// </summary>
        /// <param name="Factor"></param>
        /// <param name="Size"></param>
        static void Multiplication(int Factor, int Size)
        {
            Random Random = new Random();
            int[] Matrix = new int[Size];
            for (int i = 0; i < Size; i++)
            {
                Matrix[i] = Random.Next(-10, 10);
                Matrix[i] = Matrix[i] * Factor;
                Console.WriteLine($"{Matrix[i],4}");
            }

        }
        /// <summary>
        /// Метод сложения матриц
        /// </summary>
        /// <param name="Size"></param>
        static void Sum_Matrix(int Size)
        {
            Random Random = new Random();
            int[] Matrix1 = new int[Size]; int[] Matrix2 = new int[Size]; int[] Matrix3 = new int[Size];
            for (int i = 0; i < Size; i++)
            {
                Matrix1[i] = Random.Next(-10, 10);
                Matrix2[i] = Random.Next(-15, 15);
                Matrix3[i] = Matrix1[i] + Matrix2[i];
                Console.WriteLine($"{Matrix3[i],4}");
            }
        }
        /// <summary>
        /// Метод перемножения матриц
        /// </summary>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <param name="m"></param>
        static void Multiplication_matrix(int k, int l, int m)
        {
            int[,] A = new int[k, l];
            int[,] B = new int[l, m];
            int[,] C = new int[k, m];
            Random rnd = new Random();

            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    A[i, j] = rnd.Next(1, 9);
                    Console.Write("{0,3}", A[i, j]);
                }  
            }

            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    B[i, j] = rnd.Next(1, 9);
                }
            }

            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    C[i, j] = 0;
                    for (int q = 0; q < l; q++)
                        C[i, j] += A[i, q] * B[q, j];
                    Console.Write("{0,3}", C[i, j]);
                }
                Console.WriteLine();
            }
        }
            static void Main(string[] args)
            {
                Print("Введите число на которое хотите умножить матрицу:");
                int Factor = int.Parse(Console.ReadLine());
                Print("Введите число строк в матрцие:");
                int Size = int.Parse(Console.ReadLine());
                Multiplication(Factor, Size);
                Delay();
                Sum_Matrix(Size);
                Delay();
                int k, l, m;
                Print("Введите k:");
                k = int.Parse(Console.ReadLine());
                Print("Введите l:");
                l = int.Parse(Console.ReadLine());
                Print("Введите  m:");
                m = int.Parse(Console.ReadLine());
                Multiplication_matrix(k, l, m);
                Delay();
            }
        }
    }

