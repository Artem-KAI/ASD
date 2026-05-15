using System;

namespace lvl3;


public class BinaryTree
{
    private TreeNode root;

    public void AddStudent(Student student)
    {
        root = AddRecursive(root, student);
    }

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

    public void PrintStudentInfo()
    {
        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine($"{"Прізвище",-15}{"Ім'я",-15}{"Курс",-8}{"Квиток",-12}{"Хобі",-10}");
        Console.WriteLine("---------------------------------------------------------------");

        DFSmethod(root);

        Console.WriteLine("---------------------------------------------------------------");
    }

    private void DFSmethod(TreeNode node)
    {
        if (node == null)
            return;

        Console.WriteLine(node.Data);

        DFSmethod(node.Left);
        DFSmethod(node.Right);
    }
     
    public void DeleteStudents()
    {
        root = DeleteRecursive(root);
    }

    private TreeNode DeleteRecursive(TreeNode node)
    {
        if (node == null)
        {
            return null;
        }

        node.Left = DeleteRecursive(node.Left);
        node.Right = DeleteRecursive(node.Right);
         
        if (node.Data.Course == 2)
        {
            if (node.Data.Hobby.ToLower().Contains("спорт"))
            {
                return RemoveNode(node);
            }
        }

        return node;
    }

    private TreeNode RemoveNode(TreeNode node)
    {
        if (node.Left == null)
        {
            return node.Right;
        }
        if (node.Right == null)
        {
            return node.Left;
        }

        TreeNode min = FindMin(node.Right);
        node.Data = min.Data;
        node.Right = RemoveMin(node.Right);

        return node;
    }

    // йдемо в праву сторону, а потім в ліву, поки не знайдемо найменший елемент
    private TreeNode FindMin(TreeNode node)
    {
        while (node.Left != null)
            node = node.Left;

        return node;
    }

    private TreeNode RemoveMin(TreeNode node)
    {
        if (node.Left == null)
            return node.Right;

        node.Left = RemoveMin(node.Left);
        return node;
    }
}