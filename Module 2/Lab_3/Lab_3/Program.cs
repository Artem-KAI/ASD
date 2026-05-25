using System;

namespace lvl1
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Лабораторна робота 2.3. Завдання 1  ---");
            Console.WriteLine("Дано: 10 доповідей на конференції.");
            Console.WriteLine("Умова: Дві доповіді мають бути обов'язково поруч.");
            Console.WriteLine("Тип: Перестановка без повторень (метод склеювання).\n");

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