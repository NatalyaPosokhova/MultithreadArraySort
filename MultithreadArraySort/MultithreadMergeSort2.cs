using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadArraySort
{
    public static class MultithreadMergeSort2
    {
        public static async Task<int[]> SortAsync(int[] array)
        {
            if (array.Length < 2)
                return array;

            var leftArray = await SortImplAsync(array, Part.Left);
            var rightArray = await SortImplAsync(array, Part.Right);

            return Merge(leftArray, rightArray);
        }

        private static async Task<int[]> SortImplAsync(int[] array, Part part)
        {
            if (array.Length < 2)
                return array;

            int leftSize = array.Length / 2;
            int[] newArray;
            if (part == Part.Left)
            {
                newArray = new int[leftSize];
                Array.Copy(array, 0, newArray, 0, leftSize);
            }
            else
            {
                int rightSize = array.Length - leftSize;
                newArray = new int[rightSize];
                Array.Copy(array, leftSize, newArray, 0, rightSize);
            }

            if (newArray.Length < 2)
                return newArray;

            var leftArray = await SortImplAsync(newArray, Part.Left);
            var rightArray = await SortImplAsync(newArray, Part.Right);
            return Merge(leftArray, rightArray);
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
