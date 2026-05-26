using System;

namespace lvl2
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            { 
                int totalAvailableDigits = 4;  
                bool containsZero = true;      
                int lengthOfNumber = 3;      
                 
                double totalCombinations = CombinatoricsMath.CalculateNumbersWithRepetition(
                    totalAvailableDigits,
                    containsZero,
                    lengthOfNumber
                );

                Console.WriteLine("Логіка обчислення:");
                Console.WriteLine("1-ша позиція: 3 варіанти (2, 4, 6) - нуль не можна");
                Console.WriteLine("2-га позиція: 4 варіанти (0, 2, 4, 6)");
                Console.WriteLine("3-тя позиція: 4 варіанти (0, 2, 4, 6)\n");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Відповідь: Можна сформувати {totalCombinations} чисел.");
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