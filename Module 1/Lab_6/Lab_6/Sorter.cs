using System;

namespace lvl1
{
    public static class Sorter
    {
        // Основний метод висхідного злиття
        public static void BottomUpMergeSort(int[] array)
        {
            int n = array.Length;
            int[] temp = new int[n];

            // width — розмір підмасивів, які зливаємо (1, 2, 4, 8...)
            for (int width = 1; width < n; width *= 2)
            {
                // Проходимо по всьому масиву кроками по 2 * width
                for (int i = 0; i < n; i += 2 * width)
                {
                    int left = i;
                    int mid = Math.Min(i + width, n);
                    int right = Math.Min(i + 2 * width, n);

                    Merge(array, left, mid, right, temp);
                }
            }
        }

        // Допоміжний метод для злиття двох частин
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

            // Копіюємо відсортовану ділянку назад в оригінал
            for (int k = left; k < right; k++)
            {
                array[k] = temp[k];
            }
        }
    }
}