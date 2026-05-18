using System;
using System.Diagnostics;

namespace lvl3
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            const int SIZE = 10000;
            const int RUNS = 20; // Кількість запусків для усереднення часу

            Console.WriteLine("Дослідження часу виконання залежно від структури даних (10000 елементів)");
            Console.WriteLine("Час вказано як середнє значення за " + RUNS + " запусків у НАНОСЕКУНДАХ.");
            Console.WriteLine(new string('-', 85));
            Console.WriteLine("{0,-20} | {1,-25} | {2,-25}", "Структура даних", "Bottom-Up Час (нс)", "Top-Down Час (нс)");
            Console.WriteLine(new string('-', 85));

            // Найкращий випадок (Відсортовані)
            int[] sortedData = DataGenerator.CreateSortedArray(SIZE);
            double bestBU = MeasureAverageTimeNano(sortedData, true, RUNS);
            double bestTD = MeasureAverageTimeNano(sortedData, false, RUNS);
            Console.WriteLine("{0,-20} | {1,-25:F0} | {2,-25:F0}", "Відсортовані (Best)", bestBU, bestTD);

            // Середній випадок (Випадкові)
            int[] randomData = DataGenerator.CreateRandomArray(SIZE);
            double avgBU = MeasureAverageTimeNano(randomData, true, RUNS);
            double avgTD = MeasureAverageTimeNano(randomData, false, RUNS);
            Console.WriteLine("{0,-20} | {1,-25:F0} | {2,-25:F0}", "Випадкові (Average)", avgBU, avgTD);

            // Найгірший випадок (Відсортовані за спаданням)
            int[] reverseData = DataGenerator.CreateReverseSortedArray(SIZE);
            double worstBU = MeasureAverageTimeNano(reverseData, true, RUNS);
            double worstTD = MeasureAverageTimeNano(reverseData, false, RUNS);
            Console.WriteLine("{0,-20} | {1,-25:F0} | {2,-25:F0}", "Зворотні (Worst)", worstBU, worstTD);
 
            Console.ReadLine();
        }
         
        static double MeasureAverageTimeNano(int[] sourceData, bool isBottomUp, int runs)
        {
            double totalTimeNano = 0;
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < runs; i++)
            { 
                int[] dataToMeasure = (int[])sourceData.Clone();

                sw.Restart();
                if (isBottomUp)
                {
                    Sorter.BottomUpMergeSort(dataToMeasure);
                }
                else
                {
                    Sorter.TopDownMergeSort(dataToMeasure);
                }
                sw.Stop();
                 
                totalTimeNano += ((double)sw.ElapsedTicks / Stopwatch.Frequency) * 1_000_000_000;
            }

            return totalTimeNano / runs;
        }
    }
}