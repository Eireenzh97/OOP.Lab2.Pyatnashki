using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //---> 1
            //string path = "C:\\Users\\pastkhuf\\Desktop\\werto.txt";
            //List<int> listOfValues = GetValuesFromFile.GetList(path);


            //if (listOfValues != null)
            //{
            //    Game one = new Game(listOfValues.ToArray());
            //    StartGameByConsole(one);
            //}
            //else
            //{
            //    Console.WriteLine("Данные не получены, проверьте доступ к файлу, путь к нему и корректность данных");
            //}

            //---> 2
            //Game one = new Game(-1, 22, 3, 4, 5, 6, 7, 8, 11, 9,10, 12, 13,14,15, 0);

            //---> 3
            Game one = new Game(GetSizeByConsole());

            StartGameByConsole(one);
            Console.ReadKey();
        }
        static void StartGameByConsole(Game game)
        {
            Console.WriteLine("Для выхода введите: END");
            while (!game.IsVictory())
            {
                int value = 0;
                string tempLine;
                Game.PrintGame(game);
                Console.WriteLine("Какое значение перенeсти?");
                tempLine = Console.ReadLine();
                if (tempLine.ToLower() == "end")
                {
                    Console.WriteLine("Вы вышли из игры!");
                    return;
                }
                try
                {
                    value = int.Parse(tempLine);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (game.Shift(value) == 0)
                {
                    Console.WriteLine("Ход невозможен!");
                }     
            }
            Console.WriteLine("Congratulations! You won a cat!!!");
        }
        static int GetSizeByConsole()
        {
            Console.WriteLine("Введите размер стороны поля: ");

            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }
        }

        static void Print(Game game)
        {
            for (int x = 0; x < game.fieldSize; x++)
            {
                for (int y = 0; y < game.fieldSize; y++)
                {
                    Console.Write(game.tiles[x, y] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
