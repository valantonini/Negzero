using NUnit.Framework;
using FluentAssertions;
using Negzero.DataStructures.PriorityQueue;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Negzero.Tests.DataStructures
{
    public class FibonacciHeapTest
    {
        [Test]
        public void ShouldInstantiateFibonacciHeap()
        {
            var fibonacciHeap = new FibonacciHeap<byte>();
            fibonacciHeap.Should().NotBeNull();
        }

        [TestCase(new int[] { 2, -2 })]
        [TestCase(new int[] { 5, 2, -2, -5 })]
        [TestCase(new int[] { 5, 2, 3, 7, -2, 4, -3, 9, -4, 8, -5, -7, -8, -9 })]
        public void ShouldMaintainOrder(int[] sequence)
        {
            var fibonacciHeap = new FibonacciHeap<int>();

            foreach (var item in sequence)
            {
                if (item < 0)
                {
                    fibonacciHeap.PopMin().Should().Be(Math.Abs(item));
                }
                else
                {
                    fibonacciHeap.Push(item);
                }
            }

            Assert.Throws<System.NullReferenceException>(() => fibonacciHeap.PopMin());
        }

        [TestCase(new int[] { 2, -2 })]
        [TestCase(new int[] { 5, 2, -2, -5 })]
        [TestCase(new int[] { 5, 2, 3, 7, -2, 4, -3, 9, -4, 8, -5, -7, -8, -9 })]
        public void ShouldMaintainCount(int[] sequence)
        {
            var fibonacciHeap = new FibonacciHeap<int>();

            var numbers = new List<int>();
            foreach (var item in sequence)
            {
                if (item < 0)
                {
                    numbers.Remove(Math.Abs(item));
                    fibonacciHeap.PopMin();
                    fibonacciHeap.Count.Should().Be(numbers.Count());
                }
                else
                {
                    numbers.Add(item);
                    fibonacciHeap.Push(item);
                    fibonacciHeap.Count.Should().Be(numbers.Count());
                }
            }

            Assert.Throws<System.NullReferenceException>(() => fibonacciHeap.PopMin());
        }

        [TestCase(new byte[] { 2 })]
        [TestCase(new byte[] { 5, 2 })]
        [TestCase(new byte[] { 5, 2, 1 })]
        public void ShouldClear(byte[] sequence)
        {
            var fibonacciHeap = new FibonacciHeap<byte>();

            foreach (var item in sequence)
            {
                fibonacciHeap.Push(item);
            }

            fibonacciHeap.Clear();

            fibonacciHeap.Count.Should().Be(0);

            Assert.Throws<System.NullReferenceException>(() => fibonacciHeap.PopMin());
        }

        [TestCase(new int[] { 2, })]
        [TestCase(new int[] { 5, 2, -2 })]
        [TestCase(new int[] { 5, 2, 3, 7, -2, 4, -3, 9, -4, 8, -5, -7, -8 })]
        public void ShouldPeek(int[] sequence)
        {
            var fibonacciHeap = new FibonacciHeap<int>();
            var numbers = new List<int>();

            foreach (var item in sequence)
            {
                if (item < 0)
                {
                    numbers.Remove(Math.Abs(item));
                    fibonacciHeap.PopMin();
                    fibonacciHeap.Peek().Should().Be(numbers.Min());
                }
                else
                {
                    numbers.Add(item);
                    fibonacciHeap.Push(item);
                    fibonacciHeap.Peek().Should().Be(numbers.Min());
                }
            }
        }

        [TestCase(3, 1, new int[]{ 3, 5 }, new int[] { 4, 6 })]
        [TestCase(3, 1, new int[]{ 4, 6 }, new int[] { 3, 5 })]
        [TestCase(1, 2, new int[]{ 4, 6 }, new int[] { 3, 5 }, new int[] { 1, 9 })]
        public void ShouldMergeRootNode(int minValue, int numberOfTrees, params int[][] trees)
        {
            var rootNodes = new List<Node<int>>();

            foreach(var tree in trees)
            {
                Node<int> lastNode = null;
                for(var i = 0; i < tree.Length; i++)
                {
                    var node = new Node<int>(tree[i]);
                    if (lastNode == null)
                    {
                        lastNode = node;
                        rootNodes.Add(node);
                    }
                    else {
                        lastNode.AddChild(node);
                        lastNode = node;
                    }
                }
            }

            var (root, min) = FibonacciHeap<int>.MergeRootNodes(rootNodes, Comparer<int>.Default);

            min.Value.Should().Be(minValue);
            root.Count().Should().Be(numberOfTrees);
        }
    }
}