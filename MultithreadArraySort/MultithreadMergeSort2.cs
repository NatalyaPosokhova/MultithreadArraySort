using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadArraySort
{
    public class MultithreadMergeSort2
    {
        public async Task<int[]> SortAsync(int[] array)
        {
            if (array.Length < 2)
                return array;

            var leftArrayTask = SortImpl(array, Part.Left);
            var rightArrayTask = SortImpl(array, Part.Right);

            await leftArrayTask;
            await rightArrayTask;
            return Merge(leftArrayTask.Result, rightArrayTask.Result);
        }
        private async Task <int[]> SortImpl(int[]array,Part part)
        {
            return await SortImplAsync(array, part);
        }
        private async Task<int[]> SortImplAsync(int[] array, Part part)
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

            var leftArrayTask = SortImpl(newArray, Part.Left);
            var rightArrayTask = SortImpl(newArray, Part.Right);

            await leftArrayTask;
            await rightArrayTask;
            return Merge(leftArrayTask.Result, rightArrayTask.Result);
        }

        private enum Part
        {
            Left,
            Right
        }

        public int[] Merge(int[] leftArray, int[] rightArray)
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
