using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SinglyLinkedLists;

namespace UnitTestSinglyLinkedLists
{
    // READ: http://msdn.microsoft.com/en-us/library/hh212233.aspx

    [TestClass]
    public class UnitTestSinglyLinkedListNode
    {
        [TestMethod]
        public void NodeConstructorStoresName()
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode("foo");
            Assert.AreEqual("foo", node.Value);
        }

        [TestMethod]
        public void NodeDefaultNext()
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode("foo");
            Assert.IsNull(node.Next);
        }

        [TestMethod]
        public void NodeSetNext()
        {
            SinglyLinkedListNode node1 = new SinglyLinkedListNode("foo");
            SinglyLinkedListNode node2 = new SinglyLinkedListNode("bar");
            node1.Next = node2;
            Assert.AreEqual(node2, node1.Next);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NodeNextCantBeThis()
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode("foo");
            node.Next = node;
        }

        [TestMethod]
        public void NodeLastWhenLast()
        {
            SinglyLinkedListNode node1 = new SinglyLinkedListNode("foo");
            SinglyLinkedListNode node2 = new SinglyLinkedListNode("bar");
            node1.Next = node2;
            Assert.IsFalse(node1.IsLast()); 
        }

        [TestMethod]
        public void NodeLastWhenNotLast()
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode("foo");
            Assert.IsTrue(node.IsLast());

        }

        // READ: http://msdn.microsoft.com/en-us/library/bsc2ak47.aspx
        [TestMethod]
        public void NodeEqualityWithEqualValues()
        {
            SinglyLinkedListNode node1 = new SinglyLinkedListNode("foo");
            SinglyLinkedListNode node2 = new SinglyLinkedListNode("foo");
            Assert.AreEqual(node1, node2);
        }

        [TestMethod]
        public void NodeEqualityWithString()
        {
            SinglyLinkedListNode node1 = new SinglyLinkedListNode("foo");
            Assert.AreNotEqual(node1, "foo");
        }

        [TestMethod]
        public void NodeEqualityWithNull()
        {
            SinglyLinkedListNode node1 = new SinglyLinkedListNode("foo");
            Assert.AreNotEqual(node1, null);
        }

        [TestMethod]
        public void NodeEqualityIgnoresNext()
        {
            SinglyLinkedListNode node1 = new SinglyLinkedListNode("foo");
            node1.Next = new SinglyLinkedListNode("bob");
            SinglyLinkedListNode node2 = new SinglyLinkedListNode("foo");
            node2.Next = new SinglyLinkedListNode("sally");
            Assert.AreEqual(node1, node2);
        }

        [TestMethod]
        public void NodeInequality()
        {
            SinglyLinkedListNode node1 = new SinglyLinkedListNode("foo");
            SinglyLinkedListNode node2 = new SinglyLinkedListNode("bar");
            Assert.AreNotEqual(node1, node2);
        }

        [TestMethod]
        public void NodeGreaterThan()
        {
            SinglyLinkedListNode node1 = new SinglyLinkedListNode("foo");
            SinglyLinkedListNode node2 = new SinglyLinkedListNode("bar");
           Assert.IsTrue(node1 > node2);
        }

        [TestMethod]
        public void NodeLesserThan()
        {
            SinglyLinkedListNode node1 = new SinglyLinkedListNode("foo");
            SinglyLinkedListNode node2 = new SinglyLinkedListNode("bar");
            Assert.IsTrue(node2 < node1);
        }

        [TestMethod]
        public void NodeToString()
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode("foo");
            Assert.AreEqual("foo", node.ToString());
        }
    }
}