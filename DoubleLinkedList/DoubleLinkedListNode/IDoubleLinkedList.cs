using System;
using System.Collections.Generic;
using System.Text;

namespace MyDoubleLinkedListTest
{
    public interface IDoubleLinkedNode<T>
    {
        T Value { get; set; }
        IDoubleLinkedNode<T> Next { get; set; }
        IDoubleLinkedNode<T> Prev { get; set; }
    }

    public interface IDoubleLinkedList<T>
    {
        IDoubleLinkedNode<T> First { get; set; }
        IDoubleLinkedNode<T> Last { get; set; }
        void Reverse();
        //insert new DoubleLinkedListNode with given value at the start of the list
        void AddFirst(T value);
        //insert new DoubleLinkedListNode with given value at the end of the list
        void AddLast(T value);
    }
}
