using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        DifferentialSolver solver = new DifferentialSolver();

        Console.WriteLine("Диференціальне рівняння: dy/dx = 1 / (2x - y^2)");
        Console.WriteLine("Метод: Рунге-Кутта 2-го порядку\n");

        try
        {
            // Введення початкових даних з клавіатури
            Console.Write("Введіть початкове значення x0: ");
            double x0 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть початкове значення y0 (y(x0)): ");
            double y0 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть кінцеве значення аргументу x_end: ");
            double xEnd = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть крок інтегрування h: ");
            double h = Convert.ToDouble(Console.ReadLine());

            // Перевірка коректності інтервалу
            if (xEnd <= x0 || h <= 0)
            {
                Console.WriteLine("\nПомилка: Кінцеве значення X повинно бути більшим за початкове, а крок h > 0.");
                return;
            }

            // Виклик методу розв'язання
            List<(double x, double y)> results = solver.RungeKutta2ndOrder(x0, y0, xEnd, h);

            // Виведення результатів у вигляді таблиці
            Console.WriteLine("\nРезультати обчислення:");
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"| {"Аргумент x",-10} | {"Функція y",-13} |");
            Console.WriteLine(new string('-', 30));

            foreach (var point in results)
            {
                // Форматування з 5 знаками після коми для акуратного вигляду
                Console.WriteLine($"| {point.x,10:F5} | {point.y,13:F5} |");
            }
            Console.WriteLine(new string('-', 30));
        }
        catch (FormatException)
        {
            Console.WriteLine("\nПомилка введення! Будь ласка, використовуйте числа (для дробів використовуйте кому або крапку залежно від налаштувань ОС).");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"\nМатематична помилка: {ex.Message}");
            Console.WriteLine("Спробуйте задати інші початкові умови.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nНеочікувана помилка: {ex.Message}");
        }

        Console.ReadLine();
    }
}