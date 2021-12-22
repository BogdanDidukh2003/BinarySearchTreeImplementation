using System;

namespace BinarySearchTreeImplementation
{
    public enum Side
    {
        Left,
        Right
    }

    public class BinaryTreeNode<T> where T : IComparable
    {
        public BinaryTreeNode()
        {
        }

        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public BinaryTreeNode<T> LeftNode { get; set; }
        public BinaryTreeNode<T> RightNode { get; set; }
        public BinaryTreeNode<T> ParentNode { get; set; }

        public Side? NodeSide
        {
            get
            {
                if (ParentNode == null) return null;
                if (ParentNode.LeftNode == this) return Side.Left;
                return Side.Right;
            }
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}