using System;

namespace Praxis.Core
{
    public static class Helper
    {
        private static readonly Random RandomIntNumbers = new Random();

        public static void InsertBlankSep(int num = 1)
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write($"{Environment.NewLine}");
            }
        }

        public static int[] RandomArray(int size)
        {
            var data = new int[size];

            for (int i = 0; i < size; i++)
            {
                data[i] = RandomIntInRange(0, 9);
            }

            return data;
        }

        public static int[][] RandomMatrix(int m, int n, int min, int max)
        {
            int[][] matrix = new int[m][];
            for (int i = 0; i < m; i++)
            {
                matrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = RandomIntInRange(min, max);
                }
            }
            return matrix;
        }

        public static int[,] RandomMatrixMulti(int m, int n, int min, int max)
        {
            int[,] matrix = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = RandomIntInRange(min, max);
                }
            }
            return matrix;
        }

        public static int RandomIntInRange(int min, int max)
        {
            return RandomInt(max + 1 - min) + min;
        }

        public static int RandomInt(int n)
        {
            return RandomIntNumbers.Next(n);
        }

        public static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < 10 && matrix[i][j] > -10)
                    {
                        Console.Write(" ");
                    }
                    if (matrix[i][j] < 100 && matrix[i][j] > -100)
                    {
                        Console.Write(" ");
                    }
                    if (matrix[i][j] >= 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" " + matrix[i][j]);
                }
                Console.WriteLine();
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] < 10 && matrix[i, j] > -10)
                    {
                        Console.Write(" ");
                    }
                    if (matrix[i, j] < 100 && matrix[i, j] > -100)
                    {
                        Console.Write(" ");
                    }
                    if (matrix[i, j] >= 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(" " + matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
