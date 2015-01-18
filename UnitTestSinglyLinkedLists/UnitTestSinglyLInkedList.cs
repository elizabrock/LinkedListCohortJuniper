using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SinglyLinkedLists;

namespace UnitTestSinglyLinkedLists
{
    [TestClass]
    public class UnitTestSinglyLinkedList
    {
        [TestMethod]
        public void FirstOnEmptyList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            Assert.AreEqual(null, list.First());
        }

        [TestMethod]
        public void FirstOnShortList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            Assert.AreEqual("foo", list.First());
        }

        [TestMethod]
        public void FirstOnLongerList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            list.AddLast("bar");
            Assert.AreEqual("foo", list.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ElementAt0OnEmptyList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.ElementAt(0);
        }

        [TestMethod]
        public void ElementAt0()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            list.AddLast("bar");
            Assert.AreEqual("foo", list.ElementAt(0));
        }

        [TestMethod]
        public void ElementAt1()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddLast("grille");
            Assert.AreEqual("bar", list.ElementAt(1));
        }

        [TestMethod]
        public void ElementAtEndOfList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddLast("grille");
            Assert.AreEqual("grille", list.ElementAt(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ElementAtN()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("bar");
            list.AddLast("grille");
            list.ElementAt(5);
        }

        // CHALLENGE: Implementing negative indices, such that -1 would return "bar" and -2 would return "bar". Write tests first!
        [TestMethod]
        public void ElementAtNegativeIndex()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddLast("grille");
            list.ElementAt(-2);
        }
        
        [TestMethod]
        public void LastOnEmptyList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            Assert.AreEqual(null, list.Last());
        }

        [TestMethod]
        public void LastOnShortList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            Assert.AreEqual("foo", list.Last());
        }

        [TestMethod]
        public void LastOnLongerList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddLast("grille");
            Assert.AreEqual("grille", list.Last());
        }

        [TestMethod]
        public void ToStringOnEmptyList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            Assert.AreEqual("{ }", list.ToString());
        }

        [TestMethod]
        public void ToStringOnSingleItemList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            Assert.AreEqual("{ \"foo\" }", list.ToString());
        }

        [TestMethod]
        public void ToStringOnMultipleItemList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddLast("grille");
            Assert.AreEqual("{ \"foo\", \"bar\", \"grille\" }", list.ToString());
        }

        [TestMethod]
        public void ToArrayOnEmptyList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            string[] expected = new string[] { };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ToArrayOnSingleItemList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            string[] expected = new string[] { "foo" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ToArrayOnMultipleItemList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddLast("grille");
            string[] expected = new string[] { "foo", "bar", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void AddFirstOnEmptyList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddFirst("foo");
            string[] expected = new string[] { "foo" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void AddFirstOnLongerList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddFirst("grille");
            var expected = new string[] { "grille", "foo", "bar" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddAfterItemThatDoesntExist()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddAfter("cat", "grille");
        }

        [TestMethod]
        public void AddAfter()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            list.AddLast("grille");
            // NOTE: This assert isn't necessary.  It is merely here to remind you of / verify the state of the list prior to inserting the new node.
            var expected = new string[] { "foo", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());

            list.AddAfter("foo", "bar");
            expected = new string[] { "foo", "bar", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void AddAfterLastItem()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddAfter("bar", "grille");
            var expected = new string[] { "foo", "bar", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ConstructorWithOneArgument()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo");
            var expected = new string[] { "foo" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ConstructorWithMultipleArguments()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille");
            var expected = new string[] { "foo", "bar", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ListBracketAccessor()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille");
            Assert.AreEqual("bar", list[1]);
        }

        [TestMethod]
        public void ListBracketAssignmentSetsItem()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille");
            list[2] = "cat";
            Assert.AreEqual("cat", list[2]);
        }

        [TestMethod]
        public void ListBracketAssignmentPreservesRestOfList()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille");
            list[2] = "cat";
            var expected = new string[] { "foo", "bar", "cat" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ListRemoveFirstNode()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille");
            list.Remove("foo");
            var expected = new string[] { "bar", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ListRemoveItemFromMiddleOfList()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille");
            list.Remove("bar");
            var expected = new string[] { "foo", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ListRemoveLastItemFromList()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille");
            list.Remove("grille");
            var expected = new string[] { "foo", "bar" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ListRemoveNonExistentNode()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille");
            list.Remove("cat");
            var expected = new string[] { "foo", "bar", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void ListRemoveWithDuplicateNodes()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille", "bar");
            list.Remove("bar");
            var expected = new string[] { "foo", "grille", "bar" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void CountEmptyList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            Assert.AreEqual(0, list.Count());
        }

        [TestMethod]
        public void CountOneItemList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            Assert.AreEqual(1, list.Count());
        }
        
        [TestMethod]
        public void CountNItemList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.AddLast("foo");
            list.AddLast("bar");
            list.AddLast("grille");
            list.AddLast("baz");
            Assert.AreEqual(4, list.Count());
        }

        [TestMethod]
        public void CountChangesOnRemoval()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille");
            list.Remove("foo");
            Assert.AreEqual(2, list.Count());
            list.Remove("bar");
            Assert.AreEqual(1, list.Count());
            list.Remove("grille");
            Assert.AreEqual(0, list.Count());
        }

        [TestMethod]
        public void IndexOfNodeInFirstPosition()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille");
            Assert.AreEqual(0, list.IndexOf("foo"));
        }
        
        [TestMethod]
        public void IndexOfNodeInMiddlePosition()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille");
            Assert.AreEqual(1, list.IndexOf("bar"));
        }

        [TestMethod]
        public void IndexOfNodeInLastPosition()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille");
            Assert.AreEqual(2, list.IndexOf("grille"));
        }

        [TestMethod]
        public void IndexOfStringThatDoesntExist()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille");
            Assert.AreEqual(-1, list.IndexOf("cat"));
        }

        [TestMethod]
        public void IndexOfDuplicateNode()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "bar", "grille");
            Assert.AreEqual(1, list.IndexOf("bar"));
        }

        [TestMethod]
        public void IndexOfOnEmptyList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            Assert.AreEqual(-1, list.IndexOf("bar"));
        }

        [TestMethod]
        public void IsSortedOnEmptyList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            Assert.IsTrue(list.IsSorted());
        }

        [TestMethod]
        public void IsSortedOnSingleItemList()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo");
            Assert.IsTrue(list.IsSorted());
        }

        [TestMethod]
        public void IsSortedOnListOfDuplicates()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "foo");
            Assert.IsTrue(list.IsSorted());
        }

        [TestMethod]
        public void IsSortedOnUnsortedList()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar");
            Assert.IsFalse(list.IsSorted());
        }

        [TestMethod]
        public void IsSortedOnSortedList()
        {
            SinglyLinkedList list = new SinglyLinkedList("bar", "foo");
            Assert.IsTrue(list.IsSorted());
        }

        // This test is primarily to ensure that attempting to sort an empty list doesn't throw any exceptions
        [TestMethod]
        public void SortEmptyList()
        {
            SinglyLinkedList list = new SinglyLinkedList();
            list.Sort();
            var expected = new string[] { };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void SortSingleItemList()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo");
            list.Sort();
            var expected = new string[] { "foo" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void SortUnsortedList()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar");
            list.Sort();
            var expected = new string[] { "bar", "foo" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void SortSortedList()
        {
            SinglyLinkedList list = new SinglyLinkedList("bar", "cat", "foo", "grille");
            list.Sort();
            var expected = new string[] { "bar", "cat", "foo", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void SortLongerList()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille", "zoo", "cat");
            list.Sort();
            var expected = new string[] { "bar", "cat", "foo", "grille", "zoo" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }

        [TestMethod]
        public void SortListWithDuplicates()
        {
            SinglyLinkedList list = new SinglyLinkedList("foo", "bar", "grille", "bar");
            list.Sort();
            var expected = new string[] { "bar", "bar", "foo", "grille" };
            CollectionAssert.AreEqual(expected, list.ToArray());
        }
    }
}
