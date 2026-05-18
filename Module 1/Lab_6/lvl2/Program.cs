using System.Diagnostics;

namespace lvl2
{
    class Program
    {
        static void Main()
        {
            const int N = 100;
            int[] testSizes = { N, N * N, N * N * N };

            Console.WriteLine("Порівняння: Висхідне (BU) vs Низхідне (TD) злиття");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("{0,10} | {1,15} | {2,15}", "Розмір", "BU Час (мс)", "TD Час (мс)");
            Console.WriteLine("------------------------------------------------------------");

            foreach (int size in testSizes)
            {
                int[] sourceData = DataGenerator.CreateRandomArray(size);
                int[] dataForBU = (int[])sourceData.Clone();
                int[] dataForTD = (int[])sourceData.Clone();

                Stopwatch sw = Stopwatch.StartNew();
                Sorter.BottomUpMergeSort(dataForBU);
                sw.Stop();
                double timeBU = sw.Elapsed.TotalMilliseconds;

                sw.Restart();
                Sorter.TopDownMergeSort(dataForTD);
                sw.Stop();
                double timeTD = sw.Elapsed.TotalMilliseconds;

                Console.WriteLine("{0,10} | {1,15:F4} | {2,15:F4}", size, timeBU, timeTD);
            }

            
        }
    }
}