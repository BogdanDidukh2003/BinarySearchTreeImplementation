using System;
using NUnit.Framework;

namespace BinarySearchTreeImplementation.Tests
{
    [TestFixture]
    public class BinaryTreeNodeTests
    {
        public class DataProperty
        {
            [TestCase(5)]
            [TestCase(4.5f)]
            [TestCase('c')]
            [TestCase("cat")]
            public void TestDataProperty<T>(T data) where T : IComparable
            {
                var binaryTreeNode = new BinaryTreeNode<T>();
                binaryTreeNode.Data = data;
                Assert.AreEqual(data, binaryTreeNode.Data);
            }
        }

        public class LeftNodeProperty
        {
            private static readonly object[] SourceBinaryTreeNodes =
            {
                new BinaryTreeNode<int>(5),
                new BinaryTreeNode<float>(4.5f),
                new BinaryTreeNode<char>('c'),
                new BinaryTreeNode<string>("cat")
            };

            [TestCaseSource(nameof(SourceBinaryTreeNodes))]
            public void TestLeftNodeProperty<T>(BinaryTreeNode<T> leftNode) where T : IComparable
            {
                var binaryTreeNode = new BinaryTreeNode<T>();
                binaryTreeNode.LeftNode = leftNode;
                Assert.AreEqual(leftNode, binaryTreeNode.LeftNode);
            }
        }

        public class RightNodeProperty
        {
            private static readonly object[] SourceBinaryTreeNodes =
            {
                new BinaryTreeNode<int>(5),
                new BinaryTreeNode<float>(4.5f),
                new BinaryTreeNode<char>('c'),
                new BinaryTreeNode<string>("cat")
            };

            [TestCaseSource(nameof(SourceBinaryTreeNodes))]
            public void TestRightNodeProperty<T>(BinaryTreeNode<T> rightNode) where T : IComparable
            {
                var binaryTreeNode = new BinaryTreeNode<T>();
                binaryTreeNode.RightNode = rightNode;
                Assert.AreEqual(rightNode, binaryTreeNode.RightNode);
            }
        }

        public class ParentNodeProperty
        {
            private static readonly object[] SourceBinaryTreeNodes =
            {
                new BinaryTreeNode<int>(5),
                new BinaryTreeNode<float>(4.5f),
                new BinaryTreeNode<char>('c'),
                new BinaryTreeNode<string>("cat")
            };

            [TestCaseSource(nameof(SourceBinaryTreeNodes))]
            public void TestParentNodeProperty<T>(BinaryTreeNode<T> parentNode) where T : IComparable
            {
                var binaryTreeNode = new BinaryTreeNode<T>();
                binaryTreeNode.ParentNode = parentNode;
                Assert.AreEqual(parentNode, binaryTreeNode.ParentNode);
            }
        }

        public class BinaryTreeNodeMethod
        {
            [TestCase(5)]
            [TestCase(4.5f)]
            [TestCase('c')]
            [TestCase("cat")]
            public void TestDataProperty<T>(T data) where T : IComparable
            {
                var binaryTreeNode = new BinaryTreeNode<T>(data);
                Assert.AreEqual(data, binaryTreeNode.Data);
            }
        }

        public class NodeSideMethod
        {
            [Test]
            public void TestNoParentNode()
            {
                var binaryTreeNode = new BinaryTreeNode<IComparable>();
                binaryTreeNode.ParentNode = null;
                Assert.AreEqual(null, binaryTreeNode.NodeSide);
            }

            [Test]
            public void TestRightSide()
            {
                var binaryTreeNode = new BinaryTreeNode<IComparable>();
                var parentNode = new BinaryTreeNode<IComparable>();
                binaryTreeNode.ParentNode = parentNode;
                parentNode.RightNode = binaryTreeNode;
                Assert.AreEqual(Side.Right, binaryTreeNode.NodeSide);
            }

            [Test]
            public void TestLeftSide()
            {
                var binaryTreeNode = new BinaryTreeNode<IComparable>();
                var parentNode = new BinaryTreeNode<IComparable>();
                binaryTreeNode.ParentNode = parentNode;
                parentNode.LeftNode = binaryTreeNode;
                Assert.AreEqual(Side.Left, binaryTreeNode.NodeSide);
            }
        }

        public class ToStringMethod
        {
            [TestCase(5)]
            [TestCase(4.5f)]
            [TestCase('c')]
            [TestCase("cat")]
            public void TestDataProperty<T>(T data) where T : IComparable
            {
                var binaryTreeNode = new BinaryTreeNode<T>(data);
                Assert.AreEqual(data.ToString(), binaryTreeNode.ToString());
            }
        }
    }
}