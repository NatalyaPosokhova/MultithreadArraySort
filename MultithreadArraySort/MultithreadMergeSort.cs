﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadArraySort
{
    public static class MultithreadMergeSort
    {
        public static int[] Sort(int[] array)
        {
            if (array.Length < 2)
                return array;

            int leftSize = array.Length / 2;
            int rightSize = array.Length - leftSize;
            int[] leftArray = new int[leftSize];
            int[] rightArray = new int[rightSize];

            Array.Copy(array, 0, leftArray, 0, leftSize);
            Array.Copy(array, leftSize, rightArray, 0, rightSize);

            Sort(leftArray);
            Sort(rightArray);

            return Merge( leftArray, rightArray);
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