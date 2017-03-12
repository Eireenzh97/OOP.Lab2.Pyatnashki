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
            //первый варинт
            //string path = "C:\\Users\\Ira\\Desktop\\game.txt";
            //List<int> listOfValues = GetValuesFromFile.GetList(path);
            //if (listOfValues != null)
            //{
            //    Game game = new Game(listOfValues.ToArray());
            //    StartGame(game);
            //}
            //else
            //{
            //    Console.WriteLine("Данные не получены, проверьте доступ к файлу, путь к нему и корректность данных");
            //}

            //второй варинт
            //Game game = new Game(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0);

            //третий вариант
            Game game = new Game(GetSize());
            StartGame(game);
            Console.ReadLine();
        }
        static void StartGame(Game game)
        {

           
            while (!game.IsVictory())
            {
                int value = 0;
                string tempLine;
                Print(game);
                Console.WriteLine("Какое значение перенeсти?");
                tempLine = Console.ReadLine();
                
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
                    Console.WriteLine("Недопустимый ход!");
                }
                    
            }
            Console.WriteLine("Ваша игра закончена!");
            Print(game);

           
        }
        static int GetSize()
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
