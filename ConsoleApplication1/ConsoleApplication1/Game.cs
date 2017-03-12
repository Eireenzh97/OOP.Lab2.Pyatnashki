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
        public int[,] tiles;
        Dictionary<int, Coordinate> valuesToCoordinates;

        public int this[int x, int y]
        {
            get { return tiles[x, y]; }
            set { tiles[x, y] = value; }
        }
        public Game(params int[] tiles)
        {
            valuesToCoordinates = new Dictionary<int, Coordinate>();
            double temp = Math.Sqrt(tiles.Length);

            if (temp % 1 != 0) throw new Exception("Некорректное количество значений");
            if (!ExistZero(tiles)) throw new Exception("Не определена пустая ячейка!");

            fieldSize = Convert.ToInt32(temp);
            this.tiles = new int[fieldSize, fieldSize];
            FillArray(tiles);
            emptyTile = GetLocation(0);
        }
        public Game(int fieldSize)
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
        public Coordinate GetLocation(int value)
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
            if (coordinatesOfValue == null || !CanShift(coordinatesOfValue))
            {
                return -1;
            }
            else
            {
                tiles[emptyTile.X, emptyTile.Y] = value;
                tiles[coordinatesOfValue.X, coordinatesOfValue.Y] = 0;
                emptyTile = coordinatesOfValue;
                //update coordinates
                Coordinate temp = valuesToCoordinates[value];
                valuesToCoordinates[value] = emptyTile;
                emptyTile = temp;

                return 1;
            }
        }
        
        public bool IsVictory() //проверить правильность условия!!!!!!!!!!!!!!!!!!!!!!!
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
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
                    this.tiles[i, j] = tiles[indexCount];
                    valuesToCoordinates[tiles[indexCount++]] = new Coordinate(i, j);
                }
            }
        }
        private bool ExistZero(int[] tiles)
        {
            return tiles.Contains(0);
        }


    }
}
