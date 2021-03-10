using MyDoubleLinkedListTest;
using System;
using System.Collections.Generic;
using Xunit;

namespace MyDoubleLinkedList.Tests
{
    public class DoubleLinkedListTest
    {
        public static IEnumerable<object[]> OneNodeListData
        {
            get
            {
                var list1 = new DoubleLinkedList<int>();
                list1.AddFirst(1);

                var list2 = new DoubleLinkedList<int>();
                list2.AddLast(1);

                return new List<object[]>
                {
                    new object[] { list1 },
                    new object[] { list2 }
                };
            }
        }

        public static IEnumerable<object[]> ThreeNodeListData
        {
            get
            {
                var list1 = new DoubleLinkedList<int>();
                list1.AddFirst(3);
                list1.AddFirst(2);
                list1.AddFirst(1);

                var list2 = new DoubleLinkedList<int>();
                list2.AddLast(1);
                list2.AddLast(2);
                list2.AddLast(3);

                return new List<object[]>
                {
                    new object[] { list1 },
                    new object[] { list2 }
                };
            }
        }

        [Theory]
        [MemberData(nameof(OneNodeListData))]
        [MemberData(nameof(ThreeNodeListData))]
        public void TestFirstNode(DoubleLinkedList<int> list)
        {
            Assert.NotNull(list.First);
            Assert.Null(list.First.Prev);
            Assert.Equal(1, list.First.Value);
        }

        [Theory]
        [MemberData(nameof(OneNodeListData))]
        [MemberData(nameof(ThreeNodeListData))]
        public void TestLastNode(DoubleLinkedList<int> list)
        {
            Assert.NotNull(list.Last);
            Assert.Null(list.Last.Next);
        }


        [Theory]
        [MemberData(nameof(OneNodeListData))]
        public void TestOneNodeList(DoubleLinkedList<int> list)
        {
            Assert.NotNull(list.First);
            Assert.Equal(list.Last, list.First);
        }

        [Theory]
        [MemberData(nameof(ThreeNodeListData))]
        public void TestThreeNodeList(DoubleLinkedList<int> list)
        {
            Assert.NotEqual(list.Last, list.First);

            Assert.NotNull(list.First.Next);
            Assert.NotNull(list.Last.Prev);

            Assert.Equal(list.First.Next, list.Last.Prev);
        }

        [Theory]
        [MemberData(nameof(ThreeNodeListData))]
        public void TestReverseList(DoubleLinkedList<int> list)
        {
            Assert.NotNull(list.First);
            Assert.NotNull(list.First.Next);
            Assert.NotNull(list.Last);
            int firstValue = list.First.Value;
            int middleValue = list.First.Next.Value;
            int lastValue = list.Last.Value;

            list.Reverse();
            Assert.NotNull(list.First);
            Assert.NotNull(list.First.Next);
            Assert.NotNull(list.Last);
            Assert.NotNull(list.Last.Prev);

            Assert.Equal(lastValue, list.First.Value);
            Assert.Equal(middleValue, list.First.Next.Value);
            Assert.Equal(middleValue, list.Last.Prev.Value);
            Assert.Equal(firstValue, list.Last.Value);
        }

    }
}
