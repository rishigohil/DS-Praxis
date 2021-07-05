using System;

namespace Praxis.Core.DataStructure
{
    /// <summary>
    /// Min Stack implementation where the Stack implementation sends the minimum value stored in it.
    /// </summary>
    public class MinStack
    {
        private Node head;

        public void Push(int x)
        {
            if (head == null)
                head = new Node(x, x);
            else
                head = new Node(x, Math.Min(x, head.Min), head);
        }

        public void Pop()
        {
            head = head.Next;
        }

        public int Top()
        {
            return head.Val;
        }
        public int Min()
        {
            return head.Min;
        }

        private class Node
        {
            public int Val;
            public int Min;
            public Node Next;

            public Node(int val, int min, Node next = null)
            {
                this.Val = val;
                this.Min = min;
                this.Next = next;
            }
        }
    }
}
