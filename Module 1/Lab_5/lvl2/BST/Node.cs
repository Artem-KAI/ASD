using lvl2.Models;

namespace lvl2.BST
{
    public class Node
    {
        public Student Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(Student student)
        {
            Data = student;
            Left = null;
            Right = null;
        }
    }
}