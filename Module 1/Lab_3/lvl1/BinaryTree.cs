using System;

namespace lvl1;

public class BinaryTree
{
    private TreeNode root;

    private TreeNode AddRecursive(TreeNode node, Student student)
    {
        if (node == null)
        {
            return new TreeNode(student);
        }

        if (string.Compare(student.LastName, node.Data.LastName) < 0) // Авраменко < Іваненка = true
        {
            node.Left = AddRecursive(node.Left, student);
        }

        if (string.Compare(student.LastName, node.Data.LastName) > 0) // Авраменко > Іваненка = false
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
        if (node == null)// якщо гілка порожня, то повертаємося назад
            return;

        Console.WriteLine(node.Data);// друкуємо інформацію про студента, який знаходиться в поточному вузлі

        // рекурсивно викликаємо метод для лівої та правої гілки
        DFSmethod(node.Left);
        DFSmethod(node.Right);
    }

    public void PrintStudentInfo()
    {
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine($"{"Прізвище",-15} {"Ім'я",-15} {"Курс",-6} {"Квиток",-12} {"Хобі",-10}");
        Console.WriteLine("-------------------------------------------------------------");

        DFSmethod(root);

        Console.WriteLine("-------------------------------------------------------------");
    }
}
