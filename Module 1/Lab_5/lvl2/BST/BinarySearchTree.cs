using lvl2.Models;

namespace lvl2.BST
{
    public class BinarySearchTree
    {
        public Node Root { get; private set; }

        public void Insert(Student student)
        {
            Root = InsertRecursive(Root, student);
        }

        private Node InsertRecursive(Node root, Student student)
        {
            if (root == null) 
                return new Node(student);
             
            int comparison = string.Compare(student.FirstName, root.Data.FirstName);

            if (comparison < 0)
                root.Left = InsertRecursive(root.Left, student);
            else
                root.Right = InsertRecursive(root.Right, student);

            return root;
        }
         
        public Node Search(string firstName)
        {
            return SearchRecursive(Root, firstName);
        }

        private Node SearchRecursive(Node root, string name)
        {
            if (root == null || root.Data.FirstName == name)
                return root;

            int comparison = string.Compare(name, root.Data.FirstName);

            if (comparison < 0)
                return SearchRecursive(root.Left, name);

            return SearchRecursive(root.Right, name);
        }

        public void RotateRight()
        {
            if (Root?.Left != null)
                Root = RotateRight(Root);
        }

        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            return x;
        }
         
        public void RotateLeft()
        {
            if (Root?.Right != null) 
                Root = RotateLeft(Root);
        }

        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            return y;
        }
    }
}