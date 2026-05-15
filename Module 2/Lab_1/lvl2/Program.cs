using System;

class Program
{
    static void Main(string[] args)
    {
        EquationSolver solver = new EquationSolver();

        // Початкові дані
        double a = 0.0;           // Початок інтервалу
        double b = 1.0;           // Кінець інтервалу
        double epsilon = 0.0001;  // Задана точність (похибка)

        Console.WriteLine($"Рівняння: 2^x + 2x^2 - 3 = 0");
        Console.WriteLine($"Інтервал пошуку: [{a}, {b}], Точність = {epsilon}");
        Console.WriteLine(new string('-', 50));

        try
        {
            // Виклик методів
            double rootBisection = solver.BisectionMethod(a, b, epsilon);
            double rootSecant = solver.SecantMethod(a, b, epsilon);

            // Для методу Ньютона беремо початкове наближення (наприклад, кінець відрізка)
            double rootNewton = solver.NewtonMethod(b, epsilon);

            // Виведення результатів
            Console.WriteLine($"Метод половинного ділення: x = {rootBisection:F6}");
            Console.WriteLine($"Метод хорд:                x = {rootSecant:F6}");
            Console.WriteLine($"Метод дотичних (Ньютона):  x = {rootNewton:F6}");

            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Перевірка (підстановка кореня в f(x)): {solver.F(rootNewton):F6} (має бути близько до 0)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        Console.ReadLine();
    }
}