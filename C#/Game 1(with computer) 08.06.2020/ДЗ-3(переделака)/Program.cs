using System;

namespace ДЗ_3_переделака_
{
    class Program
    {
        static void Main(string[] args)
        {
            string User1;
            string User2;
            string GameType1;
            int GameType;
            string Error = "Неверное значение или символ, попробуй еще раз!";
            

            Console.WriteLine("Ты хочешь играть с другом или с компьютером?  1 - другом  2 - компьютером");

            while (true) ///цикл для исключения ошибки ввода
            {
                GameType1 = Console.ReadLine();
                bool R = int.TryParse(GameType1, out GameType); ///преобразование вводимого значения 
                if (R) break; else { Console.WriteLine(Error); continue; }
            }

            while (GameType == 1)///начало цикла при запуске игры(на двух игроков)
            {
                string NameGame = "Кто быстрее ?"; ///название игры
                Console.SetCursorPosition((Console.WindowWidth - NameGame.Length) / 2, Console.CursorTop); ///вывод по центру экрана 
                Console.WriteLine(NameGame);
                Console.WriteLine("Введите имена игроков");
                User1 = Console.ReadLine();///имя игрока 1
                User2 = Console.ReadLine();///имя игрока 2
                                           ///настройка уровня сложности игры
                                           ///
                Console.WriteLine("Введите максимальное число для игры");
                string MaxRangestring;
                int MaxRangint;


                while (true) ///цикл для настройки сложности игры 1.
                {
                    MaxRangestring = Console.ReadLine();///макисмальное число для игры
                    bool MaxRange = int.TryParse(MaxRangestring, out MaxRangint);
                    if (MaxRange) break; else { Console.WriteLine(Error); continue; }
                }

                Console.WriteLine("Введите максимальное чило для вычитания");
                string MaxUsertrystring;
                int MaxUsertryint;
                while (true) ///цикл для настрйоки сложности игры 2.
                {
                    MaxUsertrystring = Console.ReadLine(); ///максимальный игровой диапазон
                    bool Usertry = int.TryParse(MaxUsertrystring, out MaxUsertryint);
                    if (Usertry) break; else { Console.WriteLine(Error); continue; }
                }

                Random rand = new Random();///генерация рандоного диапазона
                int gameNumber = rand.Next(12, MaxRangint);///хранение полученого рандомного числа
                Console.WriteLine(gameNumber);///вывод для игроков этого числа

                while (gameNumber > 0) ///игровой цикл (2 игрока)
                {
                    Console.WriteLine("Ход игрока " + User1 + ", не более " + MaxUsertryint);
                    string User1trystring;
                    string User2trystring;
                    int User1Tryint;
                    int User2Tryint;

                    while (true) ///проверка ввода первого игрока
                    {
                        User1trystring = Console.ReadLine();
                        bool User1try = int.TryParse(User1trystring, out User1Tryint);
                        if (User1try) break; else { Console.WriteLine(Error); continue; }
                    }
                    if (gameNumber > 0 && User1Tryint > 0 && User1Tryint <= MaxUsertryint)
                    {
                        gameNumber = gameNumber - User1Tryint; Console.WriteLine(gameNumber);
                    }
                    else { Console.WriteLine(Error); continue; }
                    if (gameNumber == 0)
                    { Console.WriteLine("Победил игрок " + User1); break; }
                    else if (gameNumber < 0)
                    { Console.WriteLine("Это перебор, победил игрок " + User2); break; }

                    Console.WriteLine("Ход игрока " + User2 + ", не более " + MaxUsertryint);
                    while (true) ///проверка ввода второго игрока
                    {
                        User2trystring = Console.ReadLine();
                        bool User2try = int.TryParse(User2trystring, out User2Tryint);
                        if (User2try) break; else { Console.WriteLine(Error); continue;}
                    }
                    if (gameNumber > 0 && User2Tryint > 0 && User2Tryint <= MaxUsertryint)
                    {
                        gameNumber = gameNumber - User1Tryint; Console.WriteLine(gameNumber);
                    }
                    else { Console.WriteLine(Error); continue; }
                    if (gameNumber == 0)
                    { Console.WriteLine("Победил игрок " + User2); break; }
                    else if (gameNumber < 0)
                    { Console.WriteLine("Это перебор, победил игрок " + User1); break; }
                }

            }
                while (GameType == 2)
                {
                    string NameGame = "Кто быстрее ?"; ///название игры
                    Console.SetCursorPosition((Console.WindowWidth - NameGame.Length) / 2, Console.CursorTop); ///вывод по центру экрана 
                    Console.WriteLine(NameGame);
                    Console.WriteLine("Введите свое имя");
                    User1 = Console.ReadLine();///имя игрока 1

                    Console.WriteLine("Введите максимальное число для игры");
                    string MaxRangestring;
                    int MaxRangint;


                    while (true) ///цикл для настройки сложности игры 1(с компьютером).
                    {
                        MaxRangestring = Console.ReadLine();///макисмальное число для игры
                        bool MaxRange = int.TryParse(MaxRangestring, out MaxRangint);
                        if (MaxRange) break; else { Console.WriteLine(Error); continue; }
                    }

                    Console.WriteLine("Введите максимальное чило для вычитания");
                    string MaxUsertrystring;
                    int MaxUsertryint;
                    while (true) ///цикл для настрйоки сложности игры 2(с компьютером).
                    {
                        MaxUsertrystring = Console.ReadLine(); ///максимальный игровой диапазон
                        bool Usertry = int.TryParse(MaxUsertrystring, out MaxUsertryint);
                        if (Usertry) break; else { Console.WriteLine(Error); continue; }
                    }

                    Random rand = new Random();///генерация рандоного диапазона
                    Random randComp = new Random();
                    int gameNumber = rand.Next(12, MaxRangint);///хранение полученого рандомного числа
                    Console.WriteLine(gameNumber);///вывод для игроков этого числа
                    while (gameNumber > 0) ///игровой цикл (2 игрока)
                    {
                        Console.WriteLine("Ход игрока " + User1 + ", не более " + MaxUsertryint);
                        string User1trystring;
                        int User1Tryint;

                        while (true) ///проверка ввода первого игрока
                        {
                            User1trystring = Console.ReadLine();
                            bool User1try = int.TryParse(User1trystring, out User1Tryint);
                            if (User1try) break; else { Console.WriteLine(Error); continue; }
                        }
                        if (gameNumber > 0 && User1Tryint > 0 && User1Tryint <= MaxUsertryint)
                        {
                            gameNumber = gameNumber - User1Tryint; Console.WriteLine(gameNumber);
                        }
                        else { Console.WriteLine(Error); continue; }
                        if (gameNumber == 0)
                        { Console.WriteLine("Победил игрок " + User1); break; }
                        else if (gameNumber < 0)
                        { Console.WriteLine("ХАХАХ Это перебор мясной мешок!!! машины победили!!!"); break; }

                        Console.WriteLine("Ход компьютера");

                        if (gameNumber > 0) ///условие 
                        {
                            gameNumber = gameNumber - randComp.Next(0, MaxUsertryint); Console.WriteLine(gameNumber);
                        }
                        else { Console.WriteLine(Error); continue; }
                        if (gameNumber == 0)
                        { Console.WriteLine("ХАХАХ Это перебор мясной мешок!!! машины победили!!!"); break; }
                        else if (gameNumber < 0)
                        { Console.WriteLine("Это перебор, победил игрок " + User1); break; }

                    }
                
            }
        }
    }
}
