using System;

namespace BinarySearchTreeImplementation
{
    public class BinaryTree<T> where T : IComparable
    {
        public BinaryTreeNode<T> RootNode { get; set; }

        public BinaryTreeNode<T> Add(BinaryTreeNode<T> inputNode, BinaryTreeNode<T> currentNode = null)
        {
            if (RootNode == null)
            {
                inputNode.ParentNode = null;
                return RootNode = inputNode;
            }

            currentNode ??= RootNode;
            inputNode.ParentNode = currentNode;
            int result;
            if ((result = inputNode.Data.CompareTo(currentNode.Data)) == 0) return currentNode;
            if (result < 0)
            {
                if (currentNode.LeftNode == null) return currentNode.LeftNode = inputNode;
                return Add(inputNode, currentNode.LeftNode);
            }

            if (currentNode.RightNode == null) return currentNode.RightNode = inputNode;
            return Add(inputNode, currentNode.RightNode);
        }

        public BinaryTreeNode<T> Add(T data)
        {
            return Add(new BinaryTreeNode<T>(data));
        }

        public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> startWithNode = null)
        {
            startWithNode ??= RootNode;
            int result;
            if ((result = data.CompareTo(startWithNode.Data)) == 0) return startWithNode;
            if (result < 0)
            {
                if (startWithNode.LeftNode == null) return null;
                return FindNode(data, startWithNode.LeftNode);
            }
            if (startWithNode.RightNode == null) return null;
            return FindNode(data, startWithNode.RightNode);
        }


        public BinaryTreeNode<T> Remove(BinaryTreeNode<T> inputNode)
        {
            if (inputNode == null) return null;

            var currentNodeSide = inputNode.NodeSide;
            if (inputNode.LeftNode == null && inputNode.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                    inputNode.ParentNode.LeftNode = null;
                else
                    inputNode.ParentNode.RightNode = null;
            }
            else if (inputNode.LeftNode == null)
            {
                if (currentNodeSide == Side.Left)
                    inputNode.ParentNode.LeftNode = inputNode.RightNode;
                else
                    inputNode.ParentNode.RightNode = inputNode.RightNode;

                inputNode.RightNode.ParentNode = inputNode.ParentNode;
            }
            else if (inputNode.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                    inputNode.ParentNode.LeftNode = inputNode.LeftNode;
                else
                    inputNode.ParentNode.RightNode = inputNode.LeftNode;

                inputNode.LeftNode.ParentNode = inputNode.ParentNode;
            }
            else
            {
                switch (currentNodeSide)
                {
                    case Side.Left:
                        inputNode.ParentNode.LeftNode = inputNode.RightNode;
                        inputNode.RightNode.ParentNode = inputNode.ParentNode;
                        Add(inputNode.LeftNode, inputNode.RightNode);
                        break;
                    case Side.Right:
                        inputNode.ParentNode.RightNode = inputNode.RightNode;
                        inputNode.RightNode.ParentNode = inputNode.ParentNode;
                        Add(inputNode.LeftNode, inputNode.RightNode);
                        break;
                    default:
                        var bufLeft = inputNode.LeftNode;
                        var bufRightLeft = inputNode.RightNode.LeftNode;
                        var bufRightRight = inputNode.RightNode.RightNode;
                        inputNode.Data = inputNode.RightNode.Data;
                        inputNode.RightNode = bufRightRight;
                        inputNode.LeftNode = bufRightLeft;
                        Add(bufLeft, inputNode);
                        break;
                }
            }

            return inputNode;
        }

        public void Remove(T data)
        {
            var foundNode = FindNode(data);
            Remove(foundNode);
        }

        public void PrintTree()
        {
            PrintTree(RootNode);
        }

        private void PrintTree(BinaryTreeNode<T> startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}]-{startNode.Data}");
                indent += new string(' ', 3);
                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent, Side.Right);
            }
        }
    }
}