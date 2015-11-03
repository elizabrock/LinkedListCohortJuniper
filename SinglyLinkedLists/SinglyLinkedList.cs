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
            count = 0;
            
            for (int i = 0; i < values.Length; i++)
            {
                AddLast(values[i].ToString());
            }
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return ElementAt(i); }
            set {
                // ONly makes sense b/c Node is a trivial object.
                NodeAt(i).Value = value;
            }

        }

        public void AddAfter(string existingValue, string value)
        {
            if (ElementAt(-1) == existingValue)
            {
                AddLast(value);
            }
            else
            {

                SinglyLinkedListNode current = firstNode;
                bool found = false;
                while (!current.IsLast())
                {
                    if (current.Value == existingValue)
                    {
                        SinglyLinkedListNode new_node = new SinglyLinkedListNode(value);
                        SinglyLinkedListNode old_next = current.Next;
                        new_node.Next = old_next;
                        current.Next = new_node;

                        found = true;
                        break;
                    }
                    current = current.Next;
                }

                if (!found)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void AddFirst(string value)
        {
            if (firstNode == null)
            {
                AddLast(value);
            } else
            {
                SinglyLinkedListNode old_first = firstNode;
                firstNode = new SinglyLinkedListNode(value);
                firstNode.Next = old_first;
            }
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
            count++;
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            return count;
        }

        private SinglyLinkedListNode NodeAt(int index)
        {
            if (firstNode != null && index >= 0)
            {
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

                return node;
            }
            else if (index < 0)
            {
                // Count the nodes ;-)
                SinglyLinkedListNode node = firstNode;
                int length = 1;
                while (!node.IsLast())
                {
                    length++;
                    node = node.Next;
                }
                //length++;
                return this.NodeAt(length + index); //Positive index/offset
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public string ElementAt(int index)
        {
            return NodeAt(index).Value;
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
            int position = IndexOf(value);

            if (position >= 0)
            {
                if (position == 0)
                {
                    firstNode = firstNode.Next;
                }
                else if (position >= 1 && !NodeAt(position).IsLast())
                {
                    NodeAt(position - 1).Next = NodeAt(position + 1);
                }
                else if (NodeAt(position).IsLast())
                {
                    NodeAt(position - 1).Next = null;
                }
                count--;
            } 
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
