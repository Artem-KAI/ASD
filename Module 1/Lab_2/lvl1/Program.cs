namespace lvl1;

using lvl1.Hashing;
using lvl1.Models;
using System;

internal class Program
{

    static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введiть розмiр таблицi: ");
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

        HashTable hashTable = new HashTable(size);
        Random random = new Random();

        Console.Write("Скiльки елементiв вставити (без колiзiй)? ");
        int countToInsert = int.Parse(Console.ReadLine()); 

        if (countToInsert > size)
        {
            Console.WriteLine("Помилка: неможливо вставити елементiв більше, нiж розмiр таблицi ");
            return;
        }

        int inserted = 0;
        int attempts = 0;

        // працює поки не вставлено потібну кількість елементів або не перевищено ліміт спроб
        while (inserted < countToInsert && attempts < 2000)
        {
            double x = random.NextDouble() * 100; 
            double y = random.NextDouble() * 100;
            double side = 1 + random.NextDouble() * 20;

            Square newSquare = new Square(x, y, side);

            // намагаємося вставити квадрат в хеш-таблицю
            if (hashTable.Insert(newSquare))
            {
                inserted++;
            }
            attempts++;
        }

        hashTable.Display();
        Console.WriteLine($"\nУспiшно вставлено: {inserted} елементiв (спроб: {attempts}) ");
 
    }
}