using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1111111
{
    class Program
    {
        static void Main(string[] args)
        {
            int Workmonth_int;
            string Error = "Ошибка ввода, попробуйте еще раз.";
            string NameProgramm = "Финансовый учет";
            string Workmonth_string;
            Console.SetCursorPosition((Console.WindowWidth - NameProgramm.Length) / 2, Console.CursorTop); Console.WriteLine(NameProgramm);
            Console.WriteLine("Введите количесвто месяцев для оценки.");

            ///настройка объема массива 
            while (true) ///на случай ошибки ввода чила месяцев
            {
                Workmonth_string = Console.ReadLine();
                bool Workmonth = int.TryParse(Workmonth_string, out Workmonth_int);
                if (Workmonth) break; else { Console.WriteLine(Error); continue; }
            }
            string[] Workmounth_Number_string = new string[Workmonth_int]; ///масив строчечный 
            Console.WriteLine("Введите № или названия месяцов месяцов для оценки:");
            for (int i = 0; i < Workmounth_Number_string.Length; i++)
            {
                Workmounth_Number_string[i] = Console.ReadLine();///Ввод названия или номеров рабочих месяцов
            }

            ///Заполение массива данными
            int[] Data_Income_int = new int[Workmonth_int]; ///масив прихода числовой 
            int[] Data_Expenditure_int = new int[Workmonth_int];///масив расхода числовой 
            Random Rand = new Random();
            for (int i = 0; i < Workmounth_Number_string.Length; i++)///цикл сгенерированного дохода и расхода
            {
                Data_Income_int[i] = (Rand.Next(1,10))*10000;
                Data_Expenditure_int[i] = (Rand.Next(1, 10)) * 10000;
            }
            
            ///Расчет прибыли 
            int[] Profit = new int[Workmonth_int];
            int negative_Profit = 0; ///счетчик отрицательных и нулевых значений

            string Month = "Месяц:"; string Income = "Доход,"; string Expenditure = "Расход,"; string RUB = "тыс. руб."; string profit = "Прибыль,";
            Console.WriteLine($"{Month,8} {Income,10} {RUB,9} {Expenditure,10} {RUB,9} {profit,10} {RUB,9}");
            for (int i = 0; i < Workmounth_Number_string.Length; i++)
            {
                Profit[i] = Data_Income_int[i] - Data_Expenditure_int[i]; ///расчет прибыли 
                if (Profit[i] < 0 || Profit[i] == 0) negative_Profit++; ///счет на нулевую или отрицательную прибыль 
                
                Console.WriteLine($"{Workmounth_Number_string[i],8} {Data_Income_int[i],21} {Data_Expenditure_int[i],19} {Profit[i],20}");
            }
            int min = Profit[0];
            Console.WriteLine("Месяца с худшей прибылью:");
            for (int j = 0; j < 3; j++)
            {
                int MIN = Profit.Min();

                for (int i = 0; i < Workmonth_int; i++)
                {
                    //if (min > Profit[i]) //на сколько понимаю можно использовать такой вариант перебора для поиска минимального числа
                    //{
                    //    min = Profit[i];
                    //}
                    
                    if (Profit[i] == MIN)
                    {
                        int NUM_Profit = 1 + i;
                        Console.Write(NUM_Profit + " ;");
                        Profit[i] = int.MaxValue;
                    }
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("Количетсво месяцов с нулевой или отрицательной прибылью: " + negative_Profit);///вывод
            Console.ReadKey();
        }
    }
}
