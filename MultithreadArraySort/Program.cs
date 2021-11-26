using System;
using System.Collections.Generic;

namespace MultithreadArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            MergeSort.Sort(new int[] { 8, 2, 7, 6, 1, 3, 4 });

            //int[] unsortedArray = new int[] { 8, 2, 7, 6, 1, 3, 4 };
            //var multithreadMergeSort = new MultithreadMergeSort(unsortedArray);

            //var arrays = multithreadMergeSort.GetSubArrays();
            //foreach (var array in arrays)
            //{
            //    Console.WriteLine(String.Join(", ", array));
            //}

        }
    }
}
