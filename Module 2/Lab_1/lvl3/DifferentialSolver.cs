using System;
using System.Collections.Generic;

public class DifferentialSolver
{ 
    private double F(double x, double y)
    {
        double denominator = 2 * x - y * y;
         
        if (Math.Abs(denominator) < 1e-10)
        {
            throw new DivideByZeroException($"Ділення на нуль виявлено при x={x:F4}, y={y:F4}");
        }

        return 1.0 / denominator;
    }

    // Метод Рунге-Кутти 2-го порядку
    // Повертає список точок (x, y) для побудови таблиці
    public List<(double x, double y)> RungeKutta2ndOrder(double x0, double y0, double xEnd, double h)
    {
        var points = new List<(double x, double y)>();

        double x = x0;
        double y = y0;

        // Додаємо початкову точку
        points.Add((x, y));

        //  xEnd - h/2 для уникнення похибок float
        while (x < xEnd - h / 2.0)
        {
            // Формули Рунге-Кутти 2-го порядку
            double k1 = h * F(x, y);
            double k2 = h * F(x + h, y + k1);

            y = y + 0.5 * (k1 + k2);
            x = x + h;

            points.Add((x, y));
        }

        return points;
    }
}