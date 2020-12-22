using System;
using System.Collections.Generic;
using Praxis.Contracts;
using Praxis.Core;
using System.Linq;
using Praxis.Core.DataStructure;

namespace Praxis.Library
{
    public class Educative : IProblem
    {
        public void Run()
        {
            MergeSortSample();

            Helper.InsertBlankSep();

            FindFirstUnique(Helper.RandomArray(10));

            Helper.InsertBlankSep();

            FindSecondMaximum(Helper.RandomArray(10));

            Helper.InsertBlankSep();

            RotateArray();

            Helper.InsertBlankSep();

            ReArrangeArray();
        }

        /// <summary>
        /// Sample which takes an array as an input and applies MergeSort Sorting algorithm to sort it. 
        /// </summary>
        private void MergeSortSample()
        {
            var randomArr = Helper.RandomArray(10);

            Console.WriteLine("Merge Sort Implementation...");

            Console.WriteLine($"Input: {string.Join(',', randomArr)}");

            var sortedResult = SortHelper.MergeSort(randomArr);

            Console.WriteLine($"Sorted Result: {string.Join(',', sortedResult)}");

        }

        /// <summary>
        /// First Non-Repeating Integer in an Array
        /// ================================================================================
        /// Given an array, find the first integer, which is unique in the array.
        /// Unique means the number does not repeat and appears only once in the whole array.
        /// </summary>
        /// <param name="input">Input Array</param>
        private void FindFirstUnique(int[] input)
        {
            Console.WriteLine("Find First Unique...");

            Console.WriteLine($"Input: {string.Join(',', input)}");

            var bucket = new Dictionary<int, int>();

            foreach (var item in input)
            {
                if (bucket.ContainsKey(item))
                {
                    bucket[item] += 1;
                }
                else
                {
                    bucket.Add(item, 1);
                }
            }

            Console.WriteLine($"Unique Number: {bucket.Where(x => x.Value == 1).Select(x => x.Key).FirstOrDefault()}");
        }

        /// <summary>
        /// Find Second Maximum Value in an Array
        /// ================================================================================
        /// Given an array of size n,
        /// Can you find the second maximum element in the array?
        /// </summary>
        /// <param name="input"></param>
        private void FindSecondMaximum(int[] input)
        {
            Console.WriteLine("Find second maximum...");

            Console.WriteLine($"Input: {string.Join(',', input)}");

            var max = int.MinValue;
            var secondMax = int.MinValue;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > max)
                {
                    secondMax = max;
                    max = input[i];
                }
                else if (input[i] > secondMax)
                {
                    secondMax = input[i];
                }
            }

            Console.WriteLine($"Output: {secondMax}");
        }

        /// <summary>
        /// Right Rotate the Array by K Index.
        /// ================================================================================
        /// Implement the void rotateArray(int[] arr) method, which takes an arr and rotate it right by 1.
        /// </summary>
        private void RotateArray()
        {
            var inputArr = Helper.RandomArray(10);
            var k = 3;

            Console.WriteLine("Rotate Array...");
            Console.WriteLine($"Input Array: {string.Join(",", inputArr)}");

            RotateArray(inputArr, k);

            Console.WriteLine($"Rotated Array: {string.Join(",", inputArr)}");
        }

        private void RotateArray(int[] input, int k = 1)
        {
            Console.WriteLine("Rotate array from right to left...");

            Console.WriteLine($"Input: {string.Join(',', input)}");

            k %= input.Length;

            ReverseArray(input, 0, input.Length - 1);
            ReverseArray(input, 0, k - 1);
            ReverseArray(input, k, input.Length - 1);

        }

        private void ReverseArray(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        /// <summary>
        /// Rearrange array elements
        /// ================================================================================
        /// Implement a method which will sort the elements,
        /// such that all the negative elements appear at the left
        /// and positive elements appear at the right.
        /// </summary>
        private void ReArrangeArray()
        {
            Console.WriteLine("Rearrange negative and positive in array...");
            var inputArr = new int[] { 2, 4, -6, 8, -5, -10 };

            Console.WriteLine($"Input Array: {string.Join(",", inputArr)}");

            int j = 0;

            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] < 0)
                {
                    if (i != j)
                    {
                        var temp = inputArr[i];
                        inputArr[i] = inputArr[j];
                        inputArr[j] = temp;
                    }

                    j++;
                }
            }

            Console.WriteLine($"Rearranged Array: {string.Join(",", inputArr)}");
        }

        /// <summary>
        /// Reverse the linked list
        /// ================================================================================
        /// Implement a method which would reverse the linked list.
        /// </summary>
        /// <typeparam name="T">Type T of list</typeparam>
        /// <param name="list">Input List param</param>
        public void ReverseLinkedList<T>(CustomLinkedList<T> list)
        {
            if (list == null)
                return;

            CustomLinkedList<T>.ListNode prevNode = null;
            CustomLinkedList<T>.ListNode current = list.GetHeadNode();
            CustomLinkedList<T>.ListNode next = null;
            var head = list.GetHeadNode();

            while (current != null)
            {
                next = current.NextNode;
                current.NextNode = prevNode;
                prevNode = current;
                current = next;
            }

            head = prevNode;
        }

        /// <summary>
        /// Detect the loop in a given linked list
        /// ================================================================================
        /// Implement a method which detects loop in the given linked list.
        /// This method implements Floyd's cycle detection algorithm.
        /// </summary>
        /// <typeparam name="T">Type T of list</typeparam>
        /// <param name="list">Custom list as a parameter</param>
        public void DetectLinkedListLoop<T>(CustomLinkedList<T> list)
        {
            if (list == null)
                return;

            var fastNode = list.GetHeadNode();
            var slowNode = list.GetHeadNode();

            while (slowNode != null && fastNode != null && fastNode.NextNode != null)
            {
                slowNode = slowNode.NextNode;
                fastNode = fastNode.NextNode.NextNode;

                if (slowNode == fastNode)
                {
                    Console.WriteLine("//Output: Linkedlist input contains a loop.");
                    break;
                }
            }
        }

        public object KthElementFromEnd<T>(CustomLinkedList<T> list, int k)
        {
            if (list == null)
                return null;

            var length = list.Length();

            if (length <= 0)
                return null;

            var n = length - k;
            var current = list.GetHeadNode();

            if (n < 0)
                n = length;

            while (current != null)
            {
                if (n == 0)
                    return current.Data;

                current = current.NextNode;
                n--;
            }

            return null;
        }
    }
}
