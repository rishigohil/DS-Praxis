using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Praxis.Core.DataStructure
{
    public class CustomLinkedList<T>
    {
        private ListNode<T> headNode;
        private int size;

        public CustomLinkedList()
        {
            headNode = null;
            size = 0;
        }

        public ListNode<T> GetHeadNode()
        {
            return headNode;
        }

        public void SetHeadNode(ListNode<T> head)
        {
            this.headNode = head;
        }

        public bool IsEmpty()
        {
            if (headNode == null)
                return true;

            return false;
        }

        public void InsertAtHead(T data)
        {
            var newNode = new ListNode<T>
            {
                Data = data,
                NextNode = headNode
            };

            headNode = newNode;

            size++;
        }

        public void InsertAtEnd(T data)
        {
            if (IsEmpty())
            {
                InsertAtHead(data);
                return;
            }

            var newNode = new ListNode<T>()
            {
                Data = data,
                NextNode = null
            };

            var lastNode = headNode;

            while(lastNode.NextNode != null)
            {
                lastNode = lastNode.NextNode;
            }

            lastNode.NextNode = newNode;
            size++;

        }

        public void InsertAfter(T data, T previous)
        {
            if (IsEmpty())
            {
                InsertAtHead(data);
                return;
            }

            var newNode = new ListNode<T>()
            {
                Data = data
            };

            var currentNode = headNode;

            while(currentNode != null && !currentNode.Data.Equals(previous))
            {
                currentNode = currentNode.NextNode;
            }

            if(currentNode != null)
            {
                newNode.NextNode = currentNode.NextNode;
                currentNode.NextNode = newNode;
                size++;
            }
        }

        public bool ContainsNode(T data)
        {
            if (IsEmpty())
                return false;

            var currentNode = headNode;

            while(currentNode != null)
            {
                if(currentNode.Data.Equals(data))
                    return true;

                currentNode = currentNode.NextNode;
            }

            return false;
        }

        public void DeleteHead()
        {
            if (IsEmpty())
                return;

            headNode = headNode.NextNode;
            size--;
        }

        public void DeleteNode(T data)
        {
            if (IsEmpty())
                return;

            var tempNode = headNode;
            ListNode<T> prevNode = null;

            if (tempNode.Data.Equals(data))
            {
                DeleteHead();
                return;
            }

            while(tempNode.NextNode != null)
            {
                if(tempNode.Data.Equals(data))
                {
                    prevNode.NextNode = tempNode.NextNode;
                    return;
                }

                prevNode = tempNode;
                tempNode = tempNode.NextNode;
            }
        }

        public int Length()
        {
            var count = 0;

            if (IsEmpty())
                return count;

            var tempNode = headNode;

            while (tempNode != null)
            {
                count++;
                tempNode = tempNode.NextNode;
            }

            return count;
        }

        public void DeleteDuplicates()
        {
            var current = this.headNode;
            var prevNode = this.headNode;

            var visitedSet = new HashSet<T>();

            if (!IsEmpty() && current.NextNode != null)
            {
                if (visitedSet.Contains(current.Data))
                {
                    prevNode.NextNode = current.NextNode;
                    current = current.NextNode;
                }
                else
                {
                    visitedSet.Add(current.Data);
                    prevNode = current;
                    current = current.NextNode;
                }

                current = current.NextNode;
            }
        }

        public void PrintList()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty.");
                return;
            }

            var temp = headNode;

            while (temp.NextNode != null)
            {
                Console.Write($"{Convert.ToString(temp.Data)} -> ");
                temp = temp.NextNode;
            }

            Console.Write($"{Convert.ToString(temp.Data)} -> null");
        }
    }
}
