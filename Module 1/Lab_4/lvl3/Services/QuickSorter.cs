using lvl3.Models;
using System;

namespace lvl3.Services
{
    public static class QuickSorter
    {
        public static void Sort(Student[] array, int left, int right)
        {
            if (left >= right) 
                return;

            int mid = left + (right - left) / 2;

            if (string.Compare(array[left].Group, array[mid].Group) > 0) 
                Swap(array, left, mid);
            if (string.Compare(array[left].Group, array[right].Group) > 0) 
                Swap(array, left, right);
            if (string.Compare(array[mid].Group, array[right].Group) > 0) 
                Swap(array, mid, right);

            string pivot = array[mid].Group;
            int i = left;
            int j = right;

            while (i <= j)
            {
                while (string.Compare(array[i].Group, pivot) < 0) 
                    i++;
                while (string.Compare(array[j].Group, pivot) > 0) 
                    j--;

                if (i <= j)
                {
                    Swap(array, i, j);
                    i++;
                    j--;
                }
            }

            if (left < j) 
                Sort(array, left, j);
            if (i < right) 
                Sort(array, i, right);
        }

        private static void Swap(Student[] array, int a, int b)
        {
            (array[a], array[b]) = (array[b], array[a]);
        }
    }
}