using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadArraySort
{
    public class MergeSort
    {
        public int[] Sort(int[] array)
        {
            if (array.Length == 0)
                return array;
            return SortByIndexes(array, 0, array.Length - 1);
        }

        private int[] SortByIndexes(int[] array, int startIndex, int endIndex)
        {
            if (endIndex == startIndex)
                return new int[] { array[startIndex] };
            if (endIndex == startIndex + 1)
                return Merge(new int[] { array[startIndex] }, new int[] { array[endIndex] });

            var startLeftIndex = startIndex;
            var endLeftIndex = startIndex + ((endIndex - startIndex) / 2);
            var startRightIndex = endLeftIndex + 1;
            var endRightIndex = endIndex; 
            
            var leftArr = SortByIndexes(array, startLeftIndex, endLeftIndex);
            var rightArr = SortByIndexes(array, startRightIndex, endRightIndex);

            return Merge(leftArr, rightArr); 
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
