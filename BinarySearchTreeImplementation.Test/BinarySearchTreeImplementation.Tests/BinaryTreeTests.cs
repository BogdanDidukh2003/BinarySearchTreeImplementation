using System;
using NUnit.Framework;

namespace BinarySearchTreeImplementation.Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        public class RootNodeProperty
        {
            private static readonly object[] SourceBinaryTreeNodes =
            {
                new BinaryTreeNode<int>(5),
                new BinaryTreeNode<float>(4.5f),
                new BinaryTreeNode<char>('c'),
                new BinaryTreeNode<string>("cat")
            };

            [TestCaseSource(nameof(SourceBinaryTreeNodes))]
            public void TestParentNodeProperty<T>(BinaryTreeNode<T> rootNode) where T : IComparable
            {
                var binaryTree = new BinaryTree<T>();
                binaryTree.RootNode = rootNode;
                Assert.AreEqual(rootNode, binaryTree.RootNode);
            }
        }

        public class AddMethod
        {
            [TestCase(5)]
            [TestCase(4.5f)]
            [TestCase('c')]
            [TestCase("cat")]
            public void TestDataPropertyNode<T>(T node) where T : IComparable
            {
                
                var expected = new BinaryTreeNode<T>(node);
                var binaryTree = new BinaryTree<T>();
                Assert.AreEqual(expected, binaryTree.Add(expected));
            }
            [TestCase(5)]
            [TestCase(4.5f)]
            [TestCase('c')]
            [TestCase("cat")]
            public void TestDataPropertyData<T>(T data) where T : IComparable
            {
                var binaryTree = new BinaryTree<T>();
                var actualResult = binaryTree.Add(data);
                Assert.AreEqual(binaryTree.RootNode, actualResult);
            }
        }
        
        public class FindNodeMethod
        {
            [Test]
            public void TestFindNodeMethod_Parent()
            {
                var binaryTree = new BinaryTree<int>();
                var expectedResult = new BinaryTreeNode<int>(8);
                binaryTree.Add(expectedResult);
                Assert.AreEqual(expectedResult, binaryTree.FindNode(expectedResult.Data));
            }

            [Test]
            public void TestFindNodeMethod_Child()
            {
                var binaryTree = new BinaryTree<int>();
                binaryTree.Add(new BinaryTreeNode<int>(8));
                binaryTree.Add(new BinaryTreeNode<int>(3));
                var expectedResult = new BinaryTreeNode<int>(5);
                binaryTree.Add(expectedResult);
                binaryTree.Add(new BinaryTreeNode<int>(8));
                Assert.AreEqual(expectedResult, binaryTree.FindNode(expectedResult.Data));
            }
        }
        
        public class RemoveMethod
        {
            [Test]
            public void TestRemoveNodeMethod_Child()
            {
                var binaryTree = new BinaryTree<int>();
                binaryTree.Add(new BinaryTreeNode<int>(8));
                binaryTree.Add(new BinaryTreeNode<int>(3));
                var expectedResult = new BinaryTreeNode<int>(5);
                binaryTree.Add(expectedResult);
                binaryTree.Remove(expectedResult);
                Assert.AreEqual(binaryTree.FindNode(3).RightNode,null );
            }
        }
    }
}