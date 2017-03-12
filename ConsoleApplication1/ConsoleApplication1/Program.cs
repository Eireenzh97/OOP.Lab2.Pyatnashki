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
            Game game = new Game(1, 2, 3, 4, 5, 6, 7, 8, 0);


            while (!game.IsVictory())
            {
                int value = 0;
                Print(game);
                Console.WriteLine("Какое значение перенeсти?");
                try
                {
                    value = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (game.Shift(value) == -1) 
                Console.WriteLine("Недопустимый ход!");
            }
            Console.WriteLine("Поздравляю! Вы победили!");

            Console.ReadKey();
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
