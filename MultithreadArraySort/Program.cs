using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultithreadArraySort
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var test = await MultithreadMergeSort.Sort(new int[] { 8, 2, 7, 6, 1, 3, 4 });
            Console.ReadKey();
        }
    }
}
