using System.Text;
using System;

namespace lvl2;


class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        BinaryTree tree = new BinaryTree();

        tree.AddStudent(new Student("Іваненко", "Іван", 2, "MK801", "спорт"));
        tree.AddStudent(new Student("Петренко", "Петро", 1, "ST902", "музика"));
        tree.AddStudent(new Student("Сидоренко", "Олег", 3, "SB163", "спорт"));
        tree.AddStudent(new Student("Коваленко", "Анна", 2, "LK554", "спорт"));
        tree.AddStudent(new Student("Бондар", "Марія", 4, "AB123", "читання"));

        Console.WriteLine("Бінарне дерево студентів");
        Console.WriteLine("Обхід дерева: рекурсивний DFS");
        Console.WriteLine();

        tree.PrintStudentInfo();

        tree.FindStudents();

        Console.ReadKey();
    }
}
