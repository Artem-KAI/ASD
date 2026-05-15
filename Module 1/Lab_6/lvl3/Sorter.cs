using System;

namespace lvl3
{
    public static class Sorter
    {
        public static void BottomUpMergeSort(int[] array)
        {
            int n = array.Length;
            int[] temp = new int[n];
            for (int width = 1; width < n; width *= 2)
            {
                for (int i = 0; i < n; i += 2 * width)
                {
                    int left = i;
                    int mid = Math.Min(i + width, n);
                    int right = Math.Min(i + 2 * width, n);
                    Merge(array, left, mid, right, temp);
                }
            }
        }

        public static void TopDownMergeSort(int[] array)
        {
            int[] temp = new int[array.Length];
            TopDownSplitMerge(array, 0, array.Length, temp);
        }

        private static void TopDownSplitMerge(int[] array, int first, int last, int[] temp)
        {
            if (last - first <= 1) return;
            int mid = (last + first) / 2;
            TopDownSplitMerge(array, first, mid, temp);
            TopDownSplitMerge(array, mid, last, temp);
            Merge(array, first, mid, last, temp);
        }

        private static void Merge(int[] array, int left, int mid, int right, int[] temp)
        {
            int i = left;
            int j = mid;
            for (int k = left; k < right; k++)
            {
                if (i < mid && (j >= right || array[i] <= array[j]))
                {
                    temp[k] = array[i];
                    i++;
                }
                else
                {
                    temp[k] = array[j];
                    j++;
                }
            }
            for (int k = left; k < right; k++) array[k] = temp[k];
        }
    }
}