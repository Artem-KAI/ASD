using lvl2.Models;
using lvl2.Services;
using System;
using System.Text;

namespace lvl2
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Student[] students = {
                new Student("Чорна", "Маша", "KB-108", "IT-14"),
                new Student("Білий", "Артем", "KB-105", "IT-21"),
                new Student("Чорна", "Анна",  "KB-101", "AC-11"),
                new Student("Сірий", "Іван",  "KB-102", "AC-11"),
                new Student("Зелена", "Ольга", "KB-120", "BB-05"),
                new Student("Руда", "Яна",    "KB-100", "AC-11")
            };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--->>> Оригінальний масив (БЕЗ ЗМІН) <<<---");
            Console.ResetColor();
            PrintList(students, null);

            int[] sortedIndices = IndexSorter.Sort(students);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--->>> Відсортований масив (Група -> Квиток) <<<---");
            Console.ResetColor();
            PrintList(students, sortedIndices);

            Console.ReadKey();
        }

        static void PrintList(Student[] students, int[] indices)
        {
            Console.WriteLine(new string('-', 55));
            Console.WriteLine($"| {"Група",-7} | {"Квиток",-10} | {"Прізвище та ім'я",-22} |");
            Console.WriteLine(new string('-', 55));

            if (indices == null)
            {
                foreach (var s in students) Console.WriteLine(s);
            }
            else
            {
                foreach (int i in indices) Console.WriteLine(students[i]);
            }
            Console.WriteLine(new string('-', 55));
        }
    }
}