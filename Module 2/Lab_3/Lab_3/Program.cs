using System;

namespace lvl1
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.OutputEncoding = System.Text.Encoding.UTF8;
             

            try
            {
                int totalReports = 10;
                int tiedReports = 2;
                 
                int elementsToPermute = totalReports - tiedReports + 1;  
                 
                long outerPermutations = Combinatorics.Factorial(elementsToPermute);
                 
                long innerPermutations = Combinatorics.Factorial(tiedReports);
                 
                long totalWays = outerPermutations * innerPermutations;

                Console.WriteLine($"Формула: {elementsToPermute}! * {tiedReports}!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Відповідь: доповіді можна розставити {totalWays} способами.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ПОМИЛКА] {ex.Message}");
                Console.ResetColor();
            }

            Console.ReadLine();
        }
    }
}