using System;

namespace lvl2;

public class BinaryTree
{
    private TreeNode root;

    private TreeNode AddRecursive(TreeNode node, Student student)
    {
        if (node == null)
        {
            return new TreeNode(student);
        }

        if (string.Compare(student.LastName, node.Data.LastName) < 0)
        {
            node.Left = AddRecursive(node.Left, student);
        }

        if (string.Compare(student.LastName, node.Data.LastName) > 0)
        {
            node.Right = AddRecursive(node.Right, student);
        }

        return node;
    }

    public void AddStudent(Student student)
    {
        root = AddRecursive(root, student);
    }

    private void DFSmethod(TreeNode node)
    {
        if (node == null)
            return;

        Console.WriteLine(node.Data);

        DFSmethod(node.Left);
        DFSmethod(node.Right);
    }
     
    public void FindStudents()
    {
        Console.WriteLine();
        Console.WriteLine("Студенти 2 курсу, які займаються спортом:");
        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine($"{"Прізвище",-14}{"Ім'я",-14}{"Курс",-8}{"Квиток",-12}{"Хобі",-10}   |");
        Console.WriteLine("---------------------------------------------------------------");

        SearchStudent(root);

        Console.WriteLine("---------------------------------------------------------------");
    }

    private void SearchStudent(TreeNode node)
    {
        if (node == null)
        {
            return;
        }

        if (node.Data.Course == 2)
        {
            if (node.Data.Hobby.ToLower().Contains("спорт"))
            {
                Console.WriteLine(node.Data);
            }
        }

        SearchStudent(node.Left);
        SearchStudent(node.Right);
    }


    public void PrintStudentInfo()
    {
        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine($"{"Прізвище",-14}|{"Ім'я",-14}|{"Курс",-8}|{"Квиток",-12}|{"Хобі",-10}|");
        Console.WriteLine("---------------------------------------------------------------");

        DFSmethod(root);

        Console.WriteLine("---------------------------------------------------------------");
    }
}
