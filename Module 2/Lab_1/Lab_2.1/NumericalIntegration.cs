using System;

public class NumericalIntegration
{
    // Підінтегральна функція  
    private double F(double x)
    {
        return Math.Sin(Math.Sqrt(1 + x * x) + x);
    }

    // Метод лівих прямокутників
    public double RectangleMethodL(double a, double b, double step)
    {
        double sum = 0.0;
        double x = a;
        int n = (int)Math.Round((b - a) / step); // уникнення похибок
        for (int i = 0; i < n; i++)
        {
            sum += F(x + i * step);
        }
        return sum * step;
    }

    // Метод правих прямокутників
    public double RectangleMethodR(double a, double b, double step)
    {
        double sum = 0.0;
        double x = a;
        int n = (int)Math.Round((b - a) / step);
        for (int i = 1; i <= n; i++)
        {
            sum += F(x + i * step);
        }
        return sum * step;
    }

    // Метод серединних прямокутників
    public double RectangleMethodM(double a, double b, double step)
    {
        double sum = 0.0;
        double x = a + step / 2.0;
        int n = (int)Math.Round((b - a) / step);
        for (int i = 0; i < n; i++)
        {
            sum += F(x + i * step);
        }
        return sum * step;
    }

    // Метод трапецій
    public double TrapezoidMethod(double a, double b, double step)
    {
        double sum = (F(b) + F(a)) / 2.0;
        int n = (int)Math.Round((b - a) / step);
        double current; // x
        for (int i = 1; i < n; i++)
        {
            current = a + step * i;
            sum += F(current);
        }
        return sum * step;
    }

    // Метод парабол (Сімпсона)
    public double SimpsonsMethod(double a, double b, double step)
    {
        int n = (int)Math.Round((b - a) / step);

        // Перевірка на парність кількості відрізків (для Сімпсона n має бути парним)
        int nEven = (n % 2 == 0) ? n : n - 1;

        double sum = F(a) + F(a + nEven * step);
        double subSum = 0;
        double x;

        // Непарні індекси
        for (int i = 1; i < nEven; i += 2)
        {
            x = a + step * i;
            subSum += F(x);
        }
        subSum *= 4.0;
        sum += subSum;

        subSum = 0;
        // Парні індекси
        for (int i = 2; i < nEven - 1; i += 2)
        {
            x = a + step * i;
            subSum += F(x);
        }
        subSum *= 2.0;
        sum += subSum;

        double result = sum * step / 3.0;

        // Якщо n було непарним (як у вашому варіанті n=15), додаємо останній "хвіст" методом трапецій
        if (n % 2 != 0)
        {
            double x_last = a + nEven * step;
            result += step * (F(x_last) + F(b)) / 2.0;
        }

        return result;
    }
}