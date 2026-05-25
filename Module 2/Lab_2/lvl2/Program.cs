using System;

namespace lvl2
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- СИНТАКСИЧНИЙ АНАЛІЗАТОР (Рівень 2, Варіант 5) ---");
            Console.WriteLine("Паттерн: \\+\\d+[A-Z]*");
            Console.WriteLine("Правильні формати: +123, +456XYZ\n");
 
            Console.Write("Введіть текстовий образ для перевірки: ");
            string input = Console.ReadLine();
 
            var analyzer = new SyntaxAnalyzer();
            bool isValid = analyzer.Analyze(input);
             
            if (isValid)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[УСПІХ] Введений рядок ВІДПОВІДАЄ правилам автомата.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[ПОМИЛКА] Введений рядок НЕ ВІДПОВІДАЄ правилам автомата.");
            }
            Console.ResetColor();

            Console.ReadLine();
        }
    }
}