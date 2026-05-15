using System;

namespace lvl1
{
    public static class DataGenerator
    {
        private static readonly Random _random = new Random();

        public static int[] CreateRandomArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                // Числа від -1,000,000 до 1,000,000
                array[i] = _random.Next(-1000000, 1000000);
            }
            return array;
        }
    }
}