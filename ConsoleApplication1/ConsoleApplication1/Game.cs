using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApplication1
{
    class Game
    {
        public readonly int fieldSize;
        Coordinate emptyTile;
        int[,] tiles;


        public int this[int x, int y]
        {
            get { return tiles[x, y]; }
            set { tiles[x, y] = value; }
        }
        public Game(params int[] tiles)
        {
            double temp = Math.Sqrt(tiles.Length);

            if (temp % 1 != 0) throw new Exception("Некорректное количество значений");
            if (!ExistZero(tiles)) throw new Exception("Не определена пустая ячейка!");
            fieldSize = Convert.ToInt32(temp);
            this.tiles = new int[fieldSize, fieldSize]; 
            FillArray(tiles);
            emptyTile = GetLocation(0);
        }
        public Coordinate GetLocation(int value)
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    if (tiles[i, j] == value)
                    {
                        return new Coordinate(i, j);
                    }

                }
            }
            return null;
        }
        public int Shift(int value)
        {
            Coordinate coordinatesOfValue = GetLocation(value);
            if (coordinatesOfValue == null || !CanShift(coordinatesOfValue) || (value == 0))
            {
                return 0;
            }
            tiles[emptyTile.X, emptyTile.Y] = value;
            tiles[coordinatesOfValue.X, coordinatesOfValue.Y] = 0;


            emptyTile = new Coordinate(coordinatesOfValue.X, coordinatesOfValue.Y);
            return 1;
        }

        public bool IsVictory()
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    if ((i != 0 && j != 0) && tiles[fieldSize-1, fieldSize-1] != 0 &&
                        (tiles[i, j] < (j == 0 && i != 0 ? tiles[i - 1, fieldSize - 1] : tiles[i, j - 1])))
                        return false;
                }
            }
            return true;
        }

        private bool CanShift(Coordinate coordinatesOfValue)
        {
            return Math.Sqrt(Math.Pow((coordinatesOfValue.X - emptyTile.X), 2) + Math.Pow((coordinatesOfValue.Y - emptyTile.Y), 2)) == 1;
        }
        void FillArray(int[] tiles)
        {
            int indexCount = 0;
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {

                    this.tiles[i, j] = tiles[indexCount++];

                }
            }
            int count = 0;
            for (int k = 0; k < tiles.Length; k++)
            {
                int value1 = tiles[k];
                for (int i = 0; i < tiles.Length; i++)
                {
                    if (value1 == tiles[i] )
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    throw new Exception("Значения не должны повторяться");
                }
                count = 0;
            }
            

        }
        private bool ExistZero(int[] tiles)
        {
            return tiles.Contains(0);
        }
        public static void StartGame(Game game)
        {
            Console.WriteLine("Для выхода введите: END. Для продолжения нажмите Enter.");
            string tempLine;
            tempLine = Console.ReadLine();
            if (tempLine.ToLower() == "end")
            {
                Console.WriteLine("Вы вышли игры!");
                return;
            }
            while (!game.IsVictory())
            {
                int value = 0;
                PrintGame.Field(game);
                Console.WriteLine("Какое значение перенeсти?");
                
                try
                {
                    value = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (game.Shift(value) == 0)
                    Console.WriteLine("Недопустимый ход!");
            }
            Console.WriteLine("Поздравляю! Вы победили!");
        }
    }
}
