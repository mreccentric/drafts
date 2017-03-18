﻿using System;
using FluentAssertions;
using NUnit.Framework;

namespace hackerRank
{
    [TestFixture]
    internal class MinHeap_Tests
    {
        [Test]
        public void Test_ManyElements()
        {
            var heap = new MinHeap();
            for (int i = 1000; i >= 0; i--)
            {
                heap.Add(i);
                heap.GetMin().Should().Be(i);
            }
            for (int i = 0; i <=1000; i++)
            {
                heap.GetMin().Should().Be(i);
                heap.Delete(i);
            }
        }

        [Test]
        public void Test()
        {
            var heap = new MinHeap();

            heap.Add(5);
            heap.GetMin().Should().Be(5);

            heap.Add(10);
            heap.GetMin().Should().Be(5);

            heap.Delete(5);
            heap.GetMin().Should().Be(10);

            heap.Add(5);
            heap.GetMin().Should().Be(5);

            heap.Add(4);
            heap.Add(6);
            heap.Add(2);
            heap.GetMin().Should().Be(2);
        }

        [Test]
        public void Test_DeleteAll()
        {
            var heap = new MinHeap();

            heap.Add(5);
            heap.Add(10);
            heap.GetMin().Should().Be(5);

            heap.Delete(5);
            heap.Delete(10);

            heap.Add(5);
            heap.Add(10);
            heap.GetMin().Should().Be(5);
        }

        [Test]
        public void Test_NegativeNumbers()
        {
            var heap = new MinHeap();

            heap.Add(5);
            heap.Add(10);
            heap.Add(-10);
            heap.GetMin().Should().Be(-10);

            heap.Add(6);
            heap.Add(11);
            heap.GetMin().Should().Be(-10);
        }
    }

    [TestFixture]
    internal class BinaryTreeIndexer_Tests
    {
        private MinHeap.BinaryTreeIndexer indexer = new MinHeap.BinaryTreeIndexer();

        [TestCase(0, 1)]
        [TestCase(1, 3)]
        [TestCase(2, 5)]
        [TestCase(3, 7)]
        [TestCase(4, 9)]
        [TestCase(5, 11)]
        [TestCase(6, 13)]
        [TestCase(7, 15)]
        [TestCase(8, 17)]
        [TestCase(14, 29)]
        public void Test_GetLeftChildIndex(int parentIndex, int expected)
        {
            indexer.GetLeftChildIndex(parentIndex).Should().Be(expected);
        }

        [TestCase(0, 1)]
        [TestCase(1, 3)]
        [TestCase(1, 4)]
        [TestCase(2, 5)]
        [TestCase(2, 6)]
        [TestCase(3, 7)]
        [TestCase(3, 8)]
        [TestCase(4, 9)]
        [TestCase(4, 10)]
        [TestCase(5, 11)]
        [TestCase(5, 12)]
        [TestCase(6, 13)]
        [TestCase(6, 14)]
        [TestCase(7, 15)]
        [TestCase(7, 16)]
        [TestCase(8, 17)]
        [TestCase(8, 18)]
        public void Test_GetParentIndex(int expected, int childIndex)
        {
            indexer.GetParentIndex(childIndex).Should().Be(expected);
        }

        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(3, 1)]
        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(6, 2)]
        [TestCase(7, 2)]
        [TestCase(8, 3)]
        public void Test_Log(int input, int expected)
        {
            indexer.LogTwo(input).Should().Be(expected);
        }

        [Test]
        public void Test_Log2()
        {
            for (int i = 1; i < 100; i++)
            {
                indexer.LogTwo(i).Should().Be((int)Math.Log(i, 2));
            }
        }
    }
}