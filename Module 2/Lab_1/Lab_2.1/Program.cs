using System;

class Program
{
    static void Main(string[] args)
    {
        // Створюємо екземпляр класу з математичною логікою
        NumericalIntegration calculator = new NumericalIntegration();

        // Вхідні дані варіанту 5
        double a = 2.0;
        double b = 5.0;
        double step = 0.2;

        Console.WriteLine($"Iнтервал: [{a}, {b}], крок = {step}");
        Console.WriteLine(new string('-', 55));

        // Виклик методів та форматований вивід (6 знаків після коми)
        Console.WriteLine($"Метод лiвих прямокутникiв:      {calculator.RectangleMethodL(a, b, step):F6}");
        Console.WriteLine($"Метод правих прямокутникiв:     {calculator.RectangleMethodR(a, b, step):F6}");
        Console.WriteLine($"Метод серединних прямокутникiв: {calculator.RectangleMethodM(a, b, step):F6}");
        Console.WriteLine($"Метод трапецiй:                 {calculator.TrapezoidMethod(a, b, step):F6}");
        Console.WriteLine($"Метод Сiмпсона (парабол):       {calculator.SimpsonsMethod(a, b, step):F6}");

        Console.ReadLine(); // Щоб консоль не закривалась одразу (за потреби)
    }
}