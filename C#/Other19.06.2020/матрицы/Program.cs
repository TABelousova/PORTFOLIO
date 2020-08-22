using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace матрицы
{
    class Program
    {
        static void Main(string[] args)
        {
            int k, l, m;
            Console.WriteLine("Введите k:");
            k = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите l:");
            l = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите m:");
            m = int.Parse(Console.ReadLine());

            Random rnd = new Random();

            int[,] A = new int[k, l];
            int[,] B = new int[l, m];
            int[,] C = new int[k, m];

            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    A[i, j] = rnd.Next(1, 9);
                    Console.Write("{0,3}", A[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    B[i, j] = rnd.Next(1, 9);
                    Console.Write("{0,3}", B[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Перемноженная матрица");

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

            Console.ReadKey();
        }

    }
}
        
    

