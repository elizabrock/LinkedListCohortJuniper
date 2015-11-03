using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        private SinglyLinkedListNode firstNode;
        private int count;

        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            throw new NotImplementedException();
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            throw new NotImplementedException();
        }

        public void AddLast(string value)
        {
            if( firstNode == null)
            {
                firstNode = new SinglyLinkedListNode(value);
            }
            else
            {
                // Actually attach new nodes to the end of the list.
                SinglyLinkedListNode current_node = firstNode;
                while (!current_node.IsLast())
                {
                    current_node = current_node.Next;
                }
                current_node.Next = new SinglyLinkedListNode(value);
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            throw new NotImplementedException();
        }

        public string ElementAt(int index)
        {
            if (firstNode != null && index >= 0) {
                SinglyLinkedListNode node = firstNode;
                for (int i = 0; i <= index; i++)
                {
                    if (index == i)
                    {
                        break;
                    }
                    if (node.Next == null)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    node = node.Next;
                }

                return node.Value;
            } else if ( index < 0)
            {
                // Count the nodes ;-)
                SinglyLinkedListNode node = firstNode;
                int length = 1;
                while(!node.IsLast())
                {
                    length++;
                    node = node.Next;
                }
                //length++;
                return this.ElementAt(length+index); //Positive index/offset
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public string First()
        {
            if(null == firstNode)
            {
                return null;
            }
            else
            {
                return firstNode.Value;
            }
        }

        public int IndexOf(string value)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            if (firstNode == null)
            {
                return null;
            } else
            {
                return this.ElementAt(-1);
            }
        }

        public void Remove(string value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string left_br = "{";
            string right_br = "}";
            string space = " ";
            string comma = ",";
            string quote = "\"";
            StringBuilder s = new StringBuilder(left_br);
            SinglyLinkedListNode current_node = firstNode;
            while (current_node != null) {
                s.Append(space);
                s.Append(quote);
                s.Append(current_node.Value);
                s.Append(quote);
                if (current_node.IsLast())
                {
                    break;
                } else
                {
                    s.Append(comma);
                }
                current_node = current_node.Next;
            }
            s.Append(space).Append(right_br);
            return s.ToString();
        }
    }
}
