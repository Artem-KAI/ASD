using System.Diagnostics;

namespace lvl1
{
    class Program
    {
        static void Main()
        {
            const int N = 100;
            int[] testSizes = { N, N * N, N * N * N };

            Console.WriteLine("Дослідження алгоритму: Висхідне злиття");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("{0,10} | {1,15}", "Розмір (n)", "Час (мс)");
            Console.WriteLine("---------------------------------------");

            foreach (int size in testSizes)
            { 
                int[] data = DataGenerator.CreateRandomArray(size);

                // Вимірюємо час
                Stopwatch stopwatch = Stopwatch.StartNew();
                Sorter.BottomUpMergeSort(data);
                stopwatch.Stop();
                  
                Console.WriteLine("{0,10} | {1,15:F4}", size, stopwatch.Elapsed.TotalMilliseconds);
            }
        }
    }
}