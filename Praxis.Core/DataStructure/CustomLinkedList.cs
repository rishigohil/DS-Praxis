using System;
namespace Praxis.Core.DataStructure
{
    public class CustomLinkedList<T>
    {
        public class ListNode
        {
            public T Data;
            public ListNode NextNode;

        }

        public ListNode headNode;
        public int size;

        public CustomLinkedList()
        {
            headNode = null;
            size = 0;
        }

        public bool IsEmpty()
        {
            if (headNode == null)
                return true;

            return false;
        }

        public void InsertAtHead(T data)
        {
            var newNode = new ListNode
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

            var newNode = new ListNode()
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

            var newNode = new ListNode()
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
