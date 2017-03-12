using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    static class GetValuesFromFile
    {
        static public int[,] GetTable(string path)
        {
            string[] line;
            int countOfLine = CountOfLine(path);
            int countOfColumn = CountOfColumn(path);
            int[,] table;
            using (FileStream file = GetFileStream(path))
            using (StreamReader reader = (file == null ? null : new StreamReader(file)))
            {
                if (reader == null || countOfLine == -1 || countOfColumn == -1) return null;
                table = new int[countOfLine, countOfColumn];
                for (int i = 0; i < countOfLine; i++)
                {
                    line = reader.ReadLine().Split(' ');
                    for (int j = 0; j < countOfColumn; j++)
                    {
                        try { table[i, j] = int.Parse(line[j]); }
                        catch { return null; }
                    }
                }
            }
            return table;
        }
        public static List<int> GetList(string path)
        {
            List<int> table = new List<int>();
            using (FileStream file = GetFileStream(path))
            using (StreamReader reader = (file == null ? null : new StreamReader(file)))
            {
                if (reader == null) return null;
                string[] line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Split(' ');
                    for (int i = 0; i < line.Length; i++)
                    {
                        try { table.Add(int.Parse(line[i])); }
                        catch { return null; }
                    }
                }
            }
            return table;
        }

        private static int CountOfLine(string path)
        {
            int countOfLine = 0;
            using (FileStream file = GetFileStream(path))
            using (StreamReader reader = (file == null ? null : new StreamReader(file)))
            {
                if (reader == null) return -1;
                while (!reader.EndOfStream)
                {
                    reader.ReadLine();
                    countOfLine++;
                }
            }
            return countOfLine;
        }
        private static int CountOfColumn(string path)
        {

            using (FileStream file = GetFileStream(path))
            using (StreamReader reader = (file == null ? null : new StreamReader(file)))
            {
                if (reader == null) return -1;
                int countOfColumn = reader.ReadLine().Split(' ').Length;
                while (!reader.EndOfStream)
                {
                    if (reader.ReadLine().Split(' ').Length != countOfColumn) return -1;
                }
                return countOfColumn;
            }
        }
        private static FileStream GetFileStream(string path)
        {
            try
            {
                return new FileStream(path, FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return null;
            }
        }
    }
 }
