using System;
using Praxis.Contracts;
using Praxis.Core;

namespace Praxis.Library
{
    public class Educative : IProblem
    {
        public void Run()
        {
            MergeSortSample();
        }

        private void MergeSortSample()
        {
            var randomArr = Helper.RandomArray(10);

            Console.WriteLine("Merge Sort Implementation...");

            Console.WriteLine($"Input: {string.Join(',', randomArr)}");

            var sortedResult = SortHelper.MergeSort(randomArr);

            Console.WriteLine($"Sorted Result: {string.Join(',', sortedResult)}");
        }
    }
}
