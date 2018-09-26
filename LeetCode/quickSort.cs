using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class QuickSort
    {
        public static void quickSort(int[] A, int left, int right)
        {
            if (left > right || left < 0 || right < 0) return;

            int index = partition(A, left, right);

            if (index != -1)
            {
                quickSort(A, left, index - 1);
                quickSort(A, index + 1, right);
            }
        }
        private static int partition(int[] A, int left, int right)
        {
            if (left > right) return -1;

            int end = left;

            int pivot = A[right];

            for (int i = left; i < right; i++)
            {
                if (A[i] < pivot)
                {
                    swap(A, i, end);
                    end++;
                }
            }
            swap(A, end, right);

            return end;
        }
        private static void swap(int[] A, int left, int right)
        {
            int temp = A[left];
            A[left] = A[right];
            A[right] = temp;
        }
    }
}
