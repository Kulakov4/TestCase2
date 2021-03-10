using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoubleLinkedListTest
{
    public class DoubleLinkedList<T> : IDoubleLinkedList<T>
    {
        public IDoubleLinkedNode<T> First { get; set; }
        public IDoubleLinkedNode<T> Last { get; set; }

        public void AddFirst(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            IDoubleLinkedNode<T> next = First;
            First = new DoubleLinkedNode<T>(value, next, null);

            if (next != null)
                next.Prev = First;

            Last ??= First;
        }

        public void AddLast(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            IDoubleLinkedNode<T> prev = Last;
            Last = new DoubleLinkedNode<T>(value, null, prev);

            if (prev != null)
                prev.Next = Last;

            First ??= Last;
        }

        public void Reverse()
        {
            IDoubleLinkedNode<T> next, node = First;
            while (node != null)
            {
                // Меняем ссылки местами: следующий узел станет предыдущим, предыдущий станет следующим
                next = node.Next;
                node.Next = node.Prev;
                node.Prev = next;

                node = next;
            }
            // Меняем ссылку на первый и последний узел местами
            node = First;
            First = Last;
            Last = node;
        }
    }

    class DoubleLinkedNode<T> : IDoubleLinkedNode<T>
    {
        public T Value { get; set; }

        public IDoubleLinkedNode<T> Next { get; set; }
        public IDoubleLinkedNode<T> Prev { get; set; }

        public DoubleLinkedNode(T value, IDoubleLinkedNode<T> next, IDoubleLinkedNode<T> prev)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Value = value;
            Next = next;
            Prev = prev;
        }
    }
}
