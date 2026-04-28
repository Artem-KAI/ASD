using lvl3.Models;
using lvl3.Services;

namespace lvl3.Services
{
    public class SplayTree
    {
        public Node Root { get; private set; }

        private Node Splay(Node root, string name)
        {
            if (root == null || root.Data.FirstName == name)
                return root;

            int comparison = string.Compare(name, root.Data.FirstName);

            if (comparison < 0)
            {
                if (root.Left == null) return root;

                int leftComp = string.Compare(name, root.Left.Data.FirstName);

                if (leftComp < 0)
                {
                    root.Left.Left = Splay(root.Left.Left, name);
                    root = RotateRight(root);
                }
                else if (leftComp > 0)
                {
                    root.Left.Right = Splay(root.Left.Right, name);
                    if (root.Left.Right != null)
                        root.Left = RotateLeft(root.Left);
                }

                return (root.Left == null) ? root : RotateRight(root);
            }
            else
            {
                if (root.Right == null) return root;

                int rightComp = string.Compare(name, root.Right.Data.FirstName);

                if (rightComp < 0)
                {
                    root.Right.Left = Splay(root.Right.Left, name);
                    if (root.Right.Left != null)
                        root.Right = RotateRight(root.Right);
                }
                else if (rightComp > 0)
                {
                    root.Right.Right = Splay(root.Right.Right, name);
                    root = RotateLeft(root);
                }

                return (root.Right == null) ? root : RotateLeft(root);
            }
        }

        public void Insert(Student student)
        {
            if (Root == null)
            {
                Root = new Node(student);
                return;
            }

            Root = Splay(Root, student.FirstName);

            int comp = string.Compare(student.FirstName, Root.Data.FirstName);

            if (comp == 0)
                return; 

            Node newNode = new Node(student);
            if (comp < 0)
            {
                newNode.Right = Root;
                newNode.Left = Root.Left;
                Root.Left = null;
            }
            else
            {
                newNode.Left = Root;
                newNode.Right = Root.Right;
                Root.Right = null;
            }
            Root = newNode;
        }

        public Node Search(string name)
        {
            Root = Splay(Root, name);
            if (Root != null && Root.Data.FirstName == name)
                return Root;
            return null;
        }

        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            y.Left = x.Right;
            x.Right = y;
            return x;
        }

        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            x.Right = y.Left;
            y.Left = x;
            return y;
        }
    }
}