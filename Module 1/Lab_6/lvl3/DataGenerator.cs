using System;

namespace lvl3
{
    public static class DataGenerator
    {
        private static readonly Random _random = new Random();

        // Середній випадок: Випадкові дані
        public static int[] CreateRandomArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = _random.Next(-1000000, 1000000);
            }
            return array;
        }

        // Найкращий випадок: Вже відсортовані дані (за зростанням)
        public static int[] CreateSortedArray(int size)
        {
            int[] array = CreateRandomArray(size);
            Array.Sort(array); // Сортуємо вбудованим швидким методом
            return array;
        }

        // Найгірший випадок: Відсортовані за спаданням (зворотний порядок)
        public static int[] CreateReverseSortedArray(int size)
        {
            int[] array = CreateSortedArray(size);
            Array.Reverse(array);
            return array;
        }
    }
}