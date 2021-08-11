using System.Linq;

namespace csharp.Section3.Sorting
{
    public class QuickSort
    {
        public static int[] PerformQuickSort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
            return array;
        }

        public static void Sort(int[] array, int start, int end)
        {
            if (start >= end)
                return;

            int pivotIndex = start;
            int leftIdx = start + 1;
            int rightIdx = end;

            while (leftIdx <= rightIdx)
            {
                if (array[leftIdx] > array[pivotIndex] && array[rightIdx] < array[pivotIndex])
                    Swap(array, leftIdx, rightIdx);

                if (array[leftIdx] <= array[pivotIndex])
                    leftIdx++;

                if (array[rightIdx] >= array[pivotIndex])
                    rightIdx--;
            }

            Swap(array, pivotIndex, rightIdx);

            int sizeOfLeftSubarray = (rightIdx - 1) - start;
            int sizeOfRightSubarray = end - (rightIdx + 1);
            bool leftSubarrayIsSmaller = sizeOfLeftSubarray > sizeOfRightSubarray;

            if (leftSubarrayIsSmaller)
            {
                Sort(array, start, rightIdx - 1);
                Sort(array, rightIdx + 1, end);
            }
            else
            {
                Sort(array, rightIdx + 1, end);
                Sort(array, start, rightIdx - 1);
            }
        }

        public static void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}