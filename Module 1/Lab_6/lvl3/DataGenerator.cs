using System;

namespace lvl3
{
    public static class DataGenerator
    {
        private static readonly Random _random = new Random();

        public static int[] CreateRandomArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = _random.Next(-1000000, 1000000);
            }
            return array;
        }
         
        public static int[] CreateSortedArray(int size)
        {
            int[] array = CreateRandomArray(size);
            Array.Sort(array); 
            return array;
        }
         
        public static int[] CreateReverseSortedArray(int size)
        {
            int[] array = CreateSortedArray(size);
            Array.Reverse(array);
            return array;
        }
    }
}