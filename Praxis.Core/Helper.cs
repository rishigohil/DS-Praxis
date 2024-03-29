﻿using Praxis.Core.DataStructure;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;

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

        public static string WhosThere([CallerMemberName] string memberName = "")
        {
            return memberName;
        }

        public static int[] RandomArray(int size, int min, int max)
        {
            var data = new int[size];

            for (int i = 0; i < size; i++)
            {
                data[i] = RandomIntInRange(min, max);
            }

            return data;
        }

        public static int[] RandomArray(int size)
        {
            var data = new int[size];

            for (int i = 0; i < size; i++)
            {
                data[i] = RandomIntInRange(0, 99);
            }

            return data;
        }

        public static int[][] RandomMatrixJagged(int m, int n, int min, int max)
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

        public static int[,] RandomMatrix2D(int m, int n, int min, int max)
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
                for (int j = 0; j < matrix.GetLength(1); j++)
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

        public static void PrintNode(this ListNode<int> node)
        {
            if (node == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            var temp = node;

            while (temp.NextNode != null)
            {
                Console.Write($"{Convert.ToString(temp.Data)} -> ");
                temp = temp.NextNode;
            }

            Console.Write($"{Convert.ToString(temp.Data)} -> null");
        }

        public static List<List<int>> FindDistinctWithoutLinq(List<List<int>> lst)
        {
            var dic = new Dictionary<string, List<int>>();
            foreach (var item in lst)
            {
                string key = string.Join(",", item.OrderBy(c => c));

                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, item);
                }
            }

            return dic.Values.ToList();
        }

    }
}
