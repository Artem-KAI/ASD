namespace lvl2;

using lvl2.Hashing;
using lvl2.Models;
using System;

class Program
{
    static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть розмір таблиці: ");
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

        var hashTable = new HashTable(size);
        var rand = new Random();

        Console.Write("Скільки елементів згенерувати? ");

        string? input1 = Console.ReadLine();
        int count;                          

        bool isNumber = int.TryParse(input1, out count);

        if (isNumber == false)
        {
            Console.WriteLine("Некоректна кількість");
            return;
        }
        if (count < 0)
        {
            Console.WriteLine("Некоректна кількість");
            return;
        }

        for (int i = 0; i < count; i++)
        { 
            double x = rand.NextDouble() * 100;
            double y = rand.NextDouble() * 100;
            double side = 1 + rand.NextDouble() * 10;

            var s = new Square(x, y, side);
            hashTable.Insert(s);
        }

        hashTable.Display();
 
    }
}