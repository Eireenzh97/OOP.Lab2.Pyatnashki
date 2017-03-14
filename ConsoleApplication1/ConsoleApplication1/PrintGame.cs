using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class PrintGame
    {
        public static void Field(Game game)
        {
            for (int i = 0; i < game.fieldSize; i++)
            {
                for (int j = 0; j < game.fieldSize; j++)
                {
                    if (game[i, j] != 0)
                        Console.Write("{0,3}|", game[i, j]);
                    else
                        Console.Write("   |");
                }
                Console.Write("\n{0}\n", new String('-', game.fieldSize * 4));
            }
        }
        public static void Size(Game game)
        {
            Console.WriteLine(game.fieldSize);
        }
    }
}
