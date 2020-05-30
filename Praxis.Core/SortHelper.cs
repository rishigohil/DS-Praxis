using System;
namespace Praxis.Core
{
    public static class SortHelper
    {
        public static int[] MergeSort(int[] input)
        {
            int n = input.Length;

            MergeSort(input, 0, n - 1);

            return input;
        }

        private static void MergeSort(int[] input, int left, int right)
        {
            if (left < right)
            {
                //Sorted Array
                if (right - left + 1 <= 1)
                    return;

                int middle = left + (right - left) / 2;

                MergeSort(input, left, middle);
                MergeSort(input, middle + 1, right);

                Merge(input, left, middle, right);
            }

        }

        private static void Merge(int[] input, int left, int middle, int right)
        {
            //Temporary sub-arrays
            int leftHalf = middle - left + 1;
            int rightHalf = right - middle;

            var leftArr = new int[leftHalf];
            var rightArr = new int[rightHalf];

            //Copy items into subarrays
            for (int i = 0; i < leftArr.Length; i++)
                leftArr[i] = input[left + i];
            for (int j = 0; j < rightArr.Length; j++)
                rightArr[j] = input[middle + j + 1];

            /* Merge subarrays */

            //First and second array indexes
            int a = 0, b = 0;

            //Index of merged array
            int k = left;

            while (a < leftHalf && b < rightHalf)
            {
                if (leftArr[a] <= rightArr[b])
                {
                    input[k] = leftArr[a];
                    a++;
                }
                else
                {
                    input[k] = rightArr[b];
                    b++;
                }

                k++;
            }

            //Copy left out elements of left array into main array.
            while (a < leftHalf)
            {
                input[k] = leftArr[a];
                a++;
                k++;
            }

            //Copy left out elements of right array into main array.
            while (b < rightHalf)
            {
                input[k] = rightArr[b];
                b++;
                k++;
            }
        }
    }
}
