using Praxis.Contracts;
using Praxis.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Praxis.Library
{
    public class Basics : IProblem
    {
        public void Run()
        {
            DFS2D();
            BFS2D();
            BinarySearch();
        }

        public void DFS2D()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = Helper.RandomMatrix2D(4, 4, 10, 30);
            Console.WriteLine("--Input:");
            Helper.PrintMatrix(input);
            Console.WriteLine("--Output:");
            DFS2D(input);
            Helper.InsertBlankSep(1);
            Console.WriteLine("--Recursive Output:");
            DFS2DRecursive(input);
            Helper.InsertBlankSep(2);
        }

        public void BFS2D()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = Helper.RandomMatrix2D(4, 4, 30, 60);
            Console.WriteLine("--Input:");
            Helper.PrintMatrix(input);
            Console.WriteLine("--Output:");
            BFS2D(input);
            Helper.InsertBlankSep(2);
        }

        public void BinarySearch()
        {
            Console.WriteLine($"--Executing: {Helper.WhosThere()}");
            var input = Helper.RandomArray(10);
            Array.Sort(input);
            var target = input[Helper.RandomInt(9)];
            Console.WriteLine($"--Input: {string.Join(",", input)}");
            Console.WriteLine($"--Target: {target}");
            Console.WriteLine($"Output Index: {BinarySearch(input, target)}");
        }

        /// <summary>
        /// DFS Traversal on a 2D Array
        /// Approach: Use Stack to perform DFS travesal on a 2D array. Vector: (x-1,y), (x,y+1), (x+1,y), (x, y-1)
        /// </summary>
        public void DFS2D(int[,] grid)
        {
            int height = grid.GetLength(0);

            if (height == 0) return;

            int width = grid.GetLength(1);

            bool[,] visited = new bool[height, width];

            var stack = new Stack<string>();

            stack.Push($"{0},{0}");

            while (stack.Count > 0)
            {
                var val = stack.Pop();

                var row = Convert.ToInt32(val.Split(",")[0]);
                var col = Convert.ToInt32(val.Split(",")[1]);

                if (row < 0 || col < 0 || row >= height || col >= width || visited[row, col])
                    continue;

                visited[row, col] = true;
                Console.Write($"{grid[row, col]} ");
                stack.Push($"{row},{col - 1}"); //go left
                stack.Push($"{row},{col + 1}"); //go right
                stack.Push($"{row - 1},{col}"); //go up
                stack.Push($"{row + 1},{col}"); //go down
            }
        }

        public void DFS2DRecursive(int[,] grid)
        {
            int h = grid.GetLength(0);
            if (h == 0)
                return;
            int w = grid.GetLength(1);
            bool[,] visited = new bool[h, w];

            DFS2DRecursiveUtil(grid, 0, 0, visited);

        }

        public void DFS2DRecursiveUtil(int[,] grid, int row, int col, bool[,] visited)
        {
            int height = grid.GetLength(0);
            int width = grid.GetLength(1);

            if (row < 0 || col < 0 || row >= height || col >= width || visited[row, col])
                return;

            visited[row, col] = true;
            Console.Write($"{grid[row, col]} ");
            DFS2DRecursiveUtil(grid, row, col - 1, visited);
            DFS2DRecursiveUtil(grid, row, col + 1, visited);
            DFS2DRecursiveUtil(grid, row - 1, col, visited);
            DFS2DRecursiveUtil(grid, row + 1, col, visited);

        }

        /// <summary>
        /// BFS Traversal on a 2D Array
        /// Approach: Use Queue to perform BFS travesal on a 2D array. Vector: (x-1,y), (x,y+1), (x+1,y), (x, y-1)
        /// </summary>
        /// <param name="grid"></param>
        public void BFS2D(int[,] grid)
        {
            int height = grid.GetLength(0);

            if (height == 0) return;

            int width = grid.GetLength(1);

            bool[,] visited = new bool[height, width];

            var queue = new Queue<string>();

            queue.Enqueue($"{0},{0}");

            while (queue.Count > 0)
            {
                var val = queue.Dequeue();

                var row = Convert.ToInt32(val.Split(",")[0]);
                var col = Convert.ToInt32(val.Split(",")[1]);

                if (row < 0 || col < 0 || row >= height || col >= width || visited[row, col])
                    continue;

                visited[row, col] = true;
                Console.Write($"{grid[row, col]} ");
                queue.Enqueue($"{row},{col - 1}"); //go left
                queue.Enqueue($"{row},{col + 1}"); //go right
                queue.Enqueue($"{row - 1},{col}"); //go up
                queue.Enqueue($"{row + 1},{col}"); //go down
            }
        }

        /// <summary>
        /// Binary Search an array
        /// </summary>
        /// <param name="input">Input array</param>
        /// <param name="x">Target</param>
        /// <returns>Index of the target</returns>
        public int BinarySearch(int[] input, int x)
        {
            int left = 0;
            int right = input.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (input[mid] == x)
                    return mid + 1;

                if (input[mid] < x)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }
    }
}
