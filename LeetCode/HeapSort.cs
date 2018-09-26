using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class HeapSort
    {
        private static int heapSize;

        private static void buildHeap(int[] a)
        {
            heapSize = a.Length - 1;
            for (int i = heapSize / 2; i >= 0; i--)
                heapify(a, i);
        }

        private static void heapify(int[] a, int index)
        {
            int left = 2 * index;
            int right = 2 * index + 1;
            int largest = index;

            if (left <= heapSize && a[left] > a[largest])
                largest = left;
            if (right <= heapSize && a[right] > a[largest])
                largest = right;
            if (largest != index)
            {
                swap(a, index, largest);
                heapify(a, largest);
            }
        }

        public static void heapSort(int[] a)
        {
            buildHeap(a);
            for (int i = a.Length - 1; i > 0; i--)
            {
                swap(a, 0, i);
                heapSize--;
                heapify(a, 0);
            }
        }
        private static void swap(int[] A, int left, int right)
        {
            int temp = A[left];
            A[left] = A[right];
            A[right] = temp;
        }

    }
}
