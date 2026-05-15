using System;

namespace lvl3;


public class TreeNode
{
    public Student Data;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(Student data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}