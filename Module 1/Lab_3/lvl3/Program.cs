using System.Text;
using System;

namespace lvl3;


class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        BinaryTree tree = new BinaryTree();

        tree.AddStudent(new Student("Іваненко", "Іван", 2, "ST101", "спорт"));
        tree.AddStudent(new Student("Петренко", "Петро", 1, "ST102", "музика"));
        tree.AddStudent(new Student("Сидоренко", "Олег", 3, "ST103", "спорт"));
        tree.AddStudent(new Student("Коваленко", "Анна", 2, "ST104", "спорт"));
        tree.AddStudent(new Student("Бондар", "Марія", 4, "ST105", "читання"));

        Console.WriteLine("Дерево студентів (DFS):");
        tree.PrintStudentInfo();

        Console.WriteLine();
        Console.WriteLine("Видаляємо студентів 2 курсу, які займаються спортом");
        tree.DeleteStudents();

        Console.WriteLine();
        Console.WriteLine("Дерево після видалення:");
        tree.PrintStudentInfo();

        Console.ReadKey();
    }
}