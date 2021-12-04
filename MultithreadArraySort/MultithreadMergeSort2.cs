using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadArraySort
{
    public static class MultithreadMergeSort2
    {
        public static Task<int[]> SortAsync(int[] array)
        {
            throw new NotImplementedException();
        }

        private static Task<int[]> SortImplAsync(int[] array, Part part)
        {
            throw new NotImplementedException();
        }

        private enum Part
        {
            Left,
            Right
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
