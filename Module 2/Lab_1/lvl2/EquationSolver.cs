using System;

public class EquationSolver
{
    // Задана функція f(x) = 2^x + 2x^2 - 3
    public double F(double x)
    {
        return Math.Pow(2, x) + 2 * Math.Pow(x, 2) - 3;
    }

    // Похідна функції f'(x) = 2^x * ln(2) + 4x (потрібна для методу Ньютона)
    public double DF(double x)
    {
        return Math.Pow(2, x) * Math.Log(2) + 4 * x;
    }

    // 1. Метод половинного ділення (дихотомії)
    public double BisectionMethod(double a, double b, double epsilon)
    {
        if (F(a) * F(b) >= 0)
        {
            throw new ArgumentException("Функція повинна мати різні знаки на кінцях інтервалу.");
        }

        double c = a;
        while ((b - a) / 2.0 > epsilon)
        {
            c = (a + b) / 2.0;

            if (F(c) == 0.0)
                break; // Знайшли точний корінь
            else if (F(c) * F(a) < 0)
                b = c; // Корінь у лівій половині
            else
                a = c; // Корінь у правій половині
        }
        return (a + b) / 2.0;
    }

    // 2. Метод хорд (січних)
    public double SecantMethod(double a, double b, double epsilon)
    {
        double x_prev = a;
        double x_curr = b;
        double x_next;

        do
        {
            // Формула методу хорд
            x_next = x_curr - F(x_curr) * (x_curr - x_prev) / (F(x_curr) - F(x_prev));
            x_prev = x_curr;
            x_curr = x_next;

        } while (Math.Abs(F(x_curr)) > epsilon);

        return x_curr;
    }

    // 3. Метод дотичних (Ньютона)
    public double NewtonMethod(double initialGuess, double epsilon)
    {
        double x_curr = initialGuess;
        double x_next;

        do
        {
            // Формула Ньютона: x_{n+1} = x_n - f(x_n) / f'(x_n)
            x_next = x_curr - F(x_curr) / DF(x_curr);

            // Перевірка умови виходу
            if (Math.Abs(x_next - x_curr) < epsilon)
            {
                break;
            }

            x_curr = x_next;

        } while (true);

        return x_next;
    }
}