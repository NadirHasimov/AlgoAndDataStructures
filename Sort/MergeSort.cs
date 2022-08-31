using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class MergeSort
    {
        public void Sort(int[] arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int middle = left + (right - left) / 2;
            Sort(arr, left, middle);
            Sort(arr, middle + 1, right);

            Merge(arr, left, middle, right);
        }

        public void Merge(int[] arr, int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            for (int i = 0; i < leftArray.Length; i++)
            {
                leftArray[i] = arr[left + i];
            }

            for (int i = 0; i < rightArray.Length; i++)
            {
                rightArray[i] = arr[middle + i + 1];
            }

            //Console.WriteLine(String.Join(",", leftArray));
            //Console.WriteLine(String.Join(",", rightArray));
            int leftIndex = 0, rightIndex = 0, arrayIndex = left;
            while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
            {
                if (leftArray[leftIndex] < rightArray[rightIndex])
                {
                    arr[arrayIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    arr[arrayIndex] = rightArray[rightIndex];
                    rightIndex++;
                }
                arrayIndex++;
            }

            while (leftIndex < leftArray.Length)
            {
                arr[arrayIndex++] = leftArray[leftIndex++];
            }

            while (rightIndex < rightArray.Length)
            {
                arr[arrayIndex++] = rightArray[rightIndex++];
            }

        }
    }
}
