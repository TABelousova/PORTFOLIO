using System;
using System.Collections;


namespace дз2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            /// Программа "записная книжка
            Console.Write("Введите имя: "); 
            string name = Console.ReadLine(); //имя человека, переменная типо строка//
            Console.Write("Введите возраст: ");
            byte age = byte.Parse(Console.ReadLine());//возраст, переменная байт, так как нет смысла брать переменную с большим диапазоном//
            Console.Write("Введите Рост: ");
            byte height = byte.Parse(Console.ReadLine()); //рост//
            Console.Write("Введите оценку за историю: ");
            byte history = byte.Parse(Console.ReadLine()); //история//
            Console.Write("Введите оценку за русский язык: ");
            byte russian_language = byte.Parse(Console.ReadLine()); //Русский язык//
            Console.Write("Введите оценку за математику: ");
            byte math = Convert.ToByte(Console.ReadLine()); //математика//
            float average = ((float)(history + russian_language + math))/3; //средний бал, переменная с плавающей точекой//
            ///Форматироыанный вывод
            Console.WriteLine("Имя: {0} Возраст: {1} Рост: {2} Балл за историю: {3} Балл за Рус.язык: {4} Балл за математику: {5} Средний балл: {6}",
                name, age, height, history, russian_language, math, average);
            ///Интерполяция строк
            string Interstrig = String.Format("Имя: {0} Возраст: {1} Рост: {2} Балл за историю: {3} Балл за Рус.язык: {4} Балл за математику: {5} Средний балл: {6}",
                name, age, height, history, russian_language, math, average);
            Console.WriteLine(Interstrig);
            ///вывод по центру консоли по горизонтали(я так понимаю речь шла именно про горизонтальную середину)
            Console.SetCursorPosition((Console.WindowWidth - Interstrig.Length) / 2, Console.CursorTop);
            /* честно скажу не сам придумал вариант как сделал выше, но на сколько я понимаю, Console.WindowWidth используется 
             * для того что бы вычесть из обычной длинны консоли длинну строки которая получается. А Console.CursorTop это
             * фрагмент который используется для того что потом выводить именно в центре полученной координаты, строку одинково как 
             * в лево так и право*/
            Console.WriteLine(Interstrig);
            Console.ReadKey();
           
            
            


        }
    }
}
