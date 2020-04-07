using System;

namespace Praxis.Core
{
    public class Helper
    {
        private static readonly Random RandomIntNumbers = new Random();

        public static int[] RandomArray(int size)
        {
            var data = new int[size];

            for (int i = 0; i < size; i++)
            {
                data[i] = RandomIntInRange(0, 9);
            }

            return data;
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
