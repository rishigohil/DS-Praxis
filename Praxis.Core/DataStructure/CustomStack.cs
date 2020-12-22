using System;
using System.Collections.Generic;
using System.Text;

namespace Praxis.Core.DataStructure
{
    public class CustomStack<T>
    {
        T[] Data;
        int Length = 0;

        public CustomStack(int capacity)
        {
            Data = new T[capacity];
        }

        public void Push(T item)
        {
            Data[Length] = item;
            Length++;
        }

        public T Pop()
        {
            if (this.IsEmpty())
                throw new ArgumentException("Empty stack.");

            Length--;

            return Data[Length];
        }

        public T Top()
        {
            if (this.IsEmpty())
                throw new ArgumentException("Empty stack.");

            return Data[Length - 1];
        }

        public bool IsEmpty()
        {
            return Length == 0;
        }

        public int Size()
        {
            return Data.Length;
        }

        public bool IsFull()
        {
            return Length == Data.Length;
        }
    }
}
