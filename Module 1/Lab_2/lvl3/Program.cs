namespace lvl3;

using lvl3.Models;
using lvl3.Hashing;

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть розмір хеш-таблиці: ");
        string? input = Console.ReadLine();
        int size;

        if (int.TryParse(input, out size) == false)
        {
            Console.WriteLine("Некоректний розмiр");
            return;
        }
        if (size <= 0)
        {
            Console.WriteLine("Некоректний розмiр");
            return;
        }

        var ht = new HashTable(size);
        var rnd = new Random();

        Console.Write("Скільки елементів вставити (з урахуванням колізій)? ");
        if (!int.TryParse(Console.ReadLine(), out int count) || count < 0)
        {
            Console.WriteLine("Некоректна кількість.");
            return;
        }
        
        for (int i = 0; i < count; i++)
        {
            double x = rnd.NextDouble() * 100;
            double y = rnd.NextDouble() * 100;
            double side = 1 + rnd.NextDouble() * 10;  

            ht.Insert(new Square(x, y, side));
        }

        ht.Display("Вміст хеш-таблиці ДО видалення");

        Console.Write("\nВведіть поріг площі (видалити всі квадрати з меншою площею): ");
        if (!double.TryParse(Console.ReadLine(), out double s0) || s0 < 0)
        {
            Console.WriteLine("Некоректний поріг");
            return;
        }

        int removed = ht.DeleteByAreaLessThan(s0);
        Console.WriteLine($"\nВидалено елементів: {removed}");

        ht.Display("Вміст хеш-таблиці після видалення");
    }
}