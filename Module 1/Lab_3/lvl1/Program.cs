using System.Text;
using System;

namespace lvl1;


class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        BinaryTree tree = new BinaryTree();

        tree.AddStudent(new Student("Іваненко", "Іван", 2, "ST101", "Футбол"));
        tree.AddStudent(new Student("Петренко", "Петро", 1, "ST102", "Бокс"));
        tree.AddStudent(new Student("Сидоренко", "Олег", 3, "ST103", "Біг"));
        tree.AddStudent(new Student("Коваленко", "Анна", 2, "ST104", "Теніс"));
        tree.AddStudent(new Student("Бондар", "Марія", 4, "ST105", "Плавання"));

        Console.WriteLine("Бінарне дерево студентів");
        Console.WriteLine("Обхід: Рекурсивний DFS");
        Console.WriteLine();

        tree.PrintStudentInfo();

        Console.ReadKey();
    }
}
