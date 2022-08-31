using Sort;
using System;

namespace AlgoAndDataStructures.Sort
{
    class Sort
    {
        static void Main()
        {
            int[] arr = { -1, -2, 4, 0, 5, -62, 3, -1 };
            int[] left = { 1, 3 };
            int[] right = { 1, 2, 5, 7, 9 };
            int[] arrr = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            //SortUsingMerge(arrr, 0, arrr.Length - 1);
            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(arrr, 0, arrr.Length - 1);
            Console.WriteLine(string.Join(",", arrr));
        }

        static void MergeTwoSortedArray(int[] left, int[] right, int[] array)
        {
            int newLeftIndex = 0, newRightIndex = 0, newIndex = 0;
            for (int i = 0; i < array.Length && newLeftIndex < left.Length && newRightIndex < right.Length; i++)
            {
                if (left[newLeftIndex] >= right[newRightIndex])
                {
                    array[newIndex++] = right[newRightIndex++];
                }
                else
                {
                    array[newIndex++] = left[newLeftIndex++];
                }
            }

            for (int i = newLeftIndex; i < left.Length; i++)
            {
                array[newIndex++] = left[i];
            }

            for (int i = newRightIndex; i < right.Length; i++)
            {
                array[newIndex++] = right[i];
            }
        }

        static void MergeSort(int[] arr)
        {
            if (arr.Length == 1)
                return;

            int mid = arr.Length / 2;

            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];

            for (int i = 0; i < mid; i++)
                left[i] = arr[i];

            for (int i = 0; i < right.Length; i++)
                right[i] = arr[mid + i];

            MergeSort(left);
            MergeSort(right);

            MergeTwoSortedArray(left, right, arr);
        }

        static void InsertionSort(int[] arr)
        {
            int length = arr.Length;
            int key, indexForCompare;
            for (int currentIndex = 1; currentIndex < length; currentIndex++)
            {
                key = arr[currentIndex];
                indexForCompare = currentIndex - 1;
                while (indexForCompare >= 0 && arr[indexForCompare] > key)
                {
                    arr[indexForCompare + 1] = arr[indexForCompare];
                    indexForCompare--;
                }
                arr[indexForCompare + 1] = key;
            }
        }

        static void RecursiveInsertionSort(int[] arr, int n)
        {
            if (n == 1)
            {
                return;
            }

            RecursiveInsertionSort(arr, n - 1);

            int last = arr[n - 1];
            int j = n - 1 - 1;
            while (j >= 0 && last < arr[j])
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = last;
        }

        static void SelectionSort(int[] arr)
        {
            int minIndex;
            for (int j = 0; j < arr.Length - 1; j++)
            {
                minIndex = j;
                for (int i = j + 1; i < arr.Length; i++)
                {
                    if (arr[i] < arr[minIndex])
                    {
                        minIndex = i;
                    }
                }
                (arr[j], arr[minIndex]) = (arr[minIndex], arr[j]);
            }
        }

        static void BubleSort(int[] arr)
        {
            bool isSorted = true;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        isSorted = false;
                    }
                    if (isSorted) break;
                }
            }
        }

        static void BubleSortRecursive(int[] arr, int n)
        {
            if (n == 1)
            {
                return;
            }
            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                }
            }
            BubleSortRecursive(arr, n - 1);
        }

        static int[] MergeTwoSortedArray(int[] left, int[] right)
        {
            int[] arr = new int[left.Length + right.Length];

            int leftIndex = 0;
            int rightIndex = 0;
            int newArrayIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (leftIndex < left.Length && rightIndex < right.Length)
                {
                    if (left[leftIndex] <= right[rightIndex])
                    {
                        arr[newArrayIndex++] = left[leftIndex++];
                    }
                    else
                    {
                        arr[newArrayIndex++] = right[rightIndex++];
                    }
                }
                else if (leftIndex < left.Length)
                {
                    arr[newArrayIndex++] = left[leftIndex++];
                }
                else if (rightIndex < right.Length)
                {
                    arr[newArrayIndex++] = right[rightIndex++];
                }
            }
            return arr;
        }

        static void SortUsingMerge(int[] arr)
        {
            int length = arr.Length;

            if (length == 1)
            {
                return;
            }

            int middle = length / 2;
            int[] left = new int[middle];
            int[] right = new int[length - middle];
            int arrayindex = 0;
            for (int i = 0; i < left.Length; i++)
            {
                left[i] = arr[arrayindex++];
            }

            for (int i = 0; i < right.Length; i++)
            {
                right[i] = arr[arrayindex++];
            }

            SortUsingMerge(left);
            SortUsingMerge(right);

            int[] sorted = MergeTwoSortedArray(left, right);
            for (int i = 0; i < length; i++)
            {
                arr[i] = sorted[i];
            }
        }

        static void SortUsingMerge(int[] arr, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int middle = leftIndex + (rightIndex - leftIndex) / 2;

                SortUsingMerge(arr, leftIndex, middle);
                SortUsingMerge(arr, middle + 1, rightIndex);

                Merge(arr, leftIndex, middle, rightIndex);
            }
        }

        static void Merge(int[] arr, int leftIndex, int middle, int rightIndex)
        {
            int[] leftArray = new int[middle - leftIndex + 1];
            int[] rightArray = new int[rightIndex - middle];

            for (int i = 0; i < middle - leftIndex + 1; i++)
            {
                leftArray[i] = arr[leftIndex + i];
            }

            for (int i = 0; i < rightIndex - middle; i++)
            {
                rightArray[i] = rightArray[middle + i];
            }

            int newLeftIndex = 0, newRightIndex = 0, newArrayIndex = 0;
            while (newLeftIndex < leftArray.Length && newRightIndex < rightArray.Length)
            {
                if (leftArray[newLeftIndex] < rightArray[newRightIndex])
                {
                    arr[newArrayIndex] = leftArray[newLeftIndex];
                    newLeftIndex++;
                }
                else
                {
                    arr[newArrayIndex] = rightArray[newRightIndex];
                    newRightIndex++;
                }
                newArrayIndex++;
            }

            while (newRightIndex < rightArray.Length)
            {
                arr[newArrayIndex++] = rightArray[newRightIndex++];
            }

            while (newLeftIndex < leftArray.Length)
            {
                arr[newArrayIndex++] = leftArray[newLeftIndex++];
            }
        }
    }
}