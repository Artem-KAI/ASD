namespace lvl2.Hashing;

using lvl2.Models;
using System;
using System.Collections.Generic;

class HashTable
{
    private LinkedList<Square>[] table;
    private int size;

    public HashTable(int size) // в конструкторі створюється масив списків 
    {
        this.size = size;
        table = new LinkedList<Square>[size];

        for (int i = 0; i < size; i++) // кожна комірка ініціалізується як порожній список
        {
            table[i] = new LinkedList<Square>();
        }  
    }
     
    private int HashFunction(double key)
    {
        int k = (int)Math.Floor(key);
        k = Math.Abs(k);
        return k % size;
    }

    public bool Insert(Square square)
    {
        int index = HashFunction(square.GetPerimeter());
        table[index].AddLast(square);
        return true;
    } 

    public void Display()
    {
        Console.WriteLine("\n    Вміст хеш-таблиці (Роздільне зв’язування)    ");
        Console.WriteLine("{0,-5} | {1}", "Поз", "Ключ(P) -> Елемент");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', 110));
        Console.ResetColor();

        for (int i = 0; i < size; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[{0:D3}] | ", i); 
            Console.ResetColor();

            if (table[i].Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Позиція вільна");
                Console.ResetColor();
                continue;
            }            

            foreach (var item in table[i])
            {
                Console.Write($"P={item.GetPerimeter():F2} => {item}  ;  ");
            }

            Console.WriteLine();
        }
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(new string('-', 110));
        Console.ResetColor();
    }
}