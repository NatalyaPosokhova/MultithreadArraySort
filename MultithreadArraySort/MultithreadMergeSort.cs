using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultithreadArraySort
{
    public static class MultithreadMergeSort
    {
        public static async Task<int[]> Sort(int[] array)
        {
            if (array.Length < 2)
                return array;

            int leftSize = array.Length / 2;
            int rightSize = array.Length - leftSize;
            int[] leftArray = new int[leftSize];
            int[] rightArray = new int[rightSize];

            Array.Copy(array, 0, leftArray, 0, leftSize);
            Array.Copy(array, leftSize, rightArray, 0, rightSize);

            Task<int[]> task1 = Task.Run(() => Sort(leftArray));
            Task<int[]> task2 = Task.Run(() => Sort(rightArray));

            await Task.WhenAll(new List<Task<int[]>> { task1, task2 });

            var result = Merge(task1.Result, task2.Result);
            return result;
        }

        public static int[] Merge(int[] leftArray, int[] rightArray)
        {
            int[] array = new int[leftArray.Length + rightArray.Length];

            int i = 0;
            int j = 0;
            for (int k = 0; k < array.Length; k++)
            {
                if (j >= rightArray.Length)
                {
                    array[k] = leftArray[i];
                    i++;
                    continue;
                }

                if (i >= leftArray.Length)
                {
                    array[k] = rightArray[j];
                    j++;
                    continue;
                }

                if (leftArray[i] < rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
            }

            return array;
        }
    }
}
