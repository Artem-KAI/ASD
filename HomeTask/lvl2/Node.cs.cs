using System;

namespace lvl2
{
    public struct Node : IEquatable<Node>
    {
        public int Row { get; }
        public int Col { get; }

        public Node(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public bool Equals(Node other)
        {
            return Row == other.Row && Col == other.Col;
        }

        public override bool Equals(object obj)
        {
            return obj is Node other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Col);
        }

        public override string ToString()
        {
            return $"({Row}, {Col})";
        }
    }
}