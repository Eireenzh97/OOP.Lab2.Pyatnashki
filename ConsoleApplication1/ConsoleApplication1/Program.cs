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
            Game game = new Game(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0);
            Game.StartGame(game);

            Console.ReadLine();

            //string path = "C:\\Users\\Ira\\Desktop\\table.txt";
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
        }


    }
}