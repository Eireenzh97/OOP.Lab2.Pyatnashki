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
        Coordinate emptyTile; //ноль
        public int[,] tiles;//массив костяшек
        Dictionary<int, Coordinate> valuesToCoordinates;

        public int this[int x, int y] //Что такое индексатор?
        {
            get { return tiles[x, y]; }
            set { tiles[x, y] = value; }
        }
        public Game(params int[] tiles) //позволяет передавать разное кол-во аргументов
        {
            valuesToCoordinates = new Dictionary<int, Coordinate>(); //словаь нужен чтобы значениям поставить в соответствие координаты
            double temp = Math.Sqrt(tiles.Length); 

            if (temp % 1 != 0) throw new Exception("Некорректное количество значений"); //чтобы поле было квадратным, т.е 1 значение пустое или 4, 9, 16...
            if (!ExistZero(tiles)) throw new Exception("Не определена пустая ячейка!"); 

            fieldSize = Convert.ToInt32(temp);
            this.tiles = new int[fieldSize, fieldSize];//создаём квадратное поле
            FillArray(tiles);
            emptyTile = GetLocation(0); //получаем расположение пустой ячейки
        }
        public Game(int fieldSize) //другой конструктор, передаём размер поля и он рандомно заполняет
        {
            this.fieldSize = fieldSize;
            valuesToCoordinates = new Dictionary<int, Coordinate>();
            try
            {
                tiles = new int[fieldSize, fieldSize];
            }
            catch
            {
                Console.WriteLine("Недопустимый размер поля!");
                return;
            }
            GetRandomValues();
            emptyTile = GetLocation(0);
        }
        public Coordinate GetLocation(int value)//получает координаты значения
        {
            try
            {
                return valuesToCoordinates[value];
            }
            catch
            {
                return null;
            }
            
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

            //update coordinates
            Coordinate temp = valuesToCoordinates[value];
            valuesToCoordinates[value] = emptyTile;
            emptyTile = temp;

            return 1;
        }
        public static void PrintGame(Game game)  //печатать игру красиво
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
        public bool IsVictory() //проверка на победу
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)                                                          //another version
                {                                                                                            //int preceding = -1;
                    if ((i != 0 && j != 0) &&                                                                 //foreach(var item in tiles)
                        (tiles[i, j] < (j == 0 && i != 0 ? tiles[i - 1, fieldSize - 1] : tiles[i, j - 1])))    //{
                        return false;                                                                        //   if(preceding>item) return false  
                }                                                                                            //   preceding = item; 
            }
            return true;
        }
        private void GetRandomValues()
        {
            Random gen = new Random();
            List<int> values = new List<int>();
            int randomValue;

            for (int i = 0; i < fieldSize * fieldSize; i++)
            {
                values.Add(i);
            }

            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    randomValue = gen.Next(0, values.Count);
                    tiles[i, j] = values[randomValue];
                    valuesToCoordinates[values[randomValue]] = new Coordinate(i, j);
                    values.RemoveAt(randomValue);
                }
            }
        }
        private bool CanShift(Coordinate coordinateOfValue) //проверяет можно ли переместить значение
        {
            return Math.Sqrt(Math.Pow((coordinateOfValue.X - emptyTile.X), 2) + Math.Pow((coordinateOfValue.Y - emptyTile.Y), 2)) == 1;
        }
        void FillArray(int[] tiles) //проверяет на правильность заполнения поля игры //ContainsKey-проверяет содержится ли указанныйключ в словаре
        {
            int indexCount = 0;
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    this.tiles[i, j] = tiles[indexCount];
                    if (valuesToCoordinates.ContainsKey(tiles[indexCount]))
                    {
                        throw new Exception("Повторяются значения");
                    }
                    valuesToCoordinates[tiles[indexCount++]] = new Coordinate(i, j); //новая координата создаётся
                }
            }
        }
        private bool ExistZero(int[] tiles) //проверяет есть ли ноль
        {
            return tiles.Contains(0);
        }
        
    }

}
