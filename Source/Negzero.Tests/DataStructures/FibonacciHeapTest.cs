using NUnit.Framework;
using FluentAssertions;
using Negzero.DataStructures.PriorityQueue;

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

        [TestCase(new byte[]{ 2 }, new byte[]{ 2 })]
        [TestCase(new byte[]{ 5, 2 }, new byte[]{ 2, 5 })]
        public void ShouldMaintainPriorityOrder(byte[] sequence, byte[] expected)
        {
            var fibonacciHeap = new FibonacciHeap<byte>();
            
            foreach(var item in sequence)
            {
                fibonacciHeap.Push(item);
            }

            for(var i = 0; i < expected.Length; i++) 
            {
                var actual = fibonacciHeap.PopMin();
                actual.Should().Be(expected[i]);
            }
        }

        [TestCase(new byte[]{ 2 })]
        [TestCase(new byte[]{ 5, 2 })]
        [TestCase(new byte[]{ 5, 2, 3, 7 })]
        public void ShouldMaintainCount(byte[] sequence)
        {
            var fibonacciHeap = new FibonacciHeap<byte>();
            
            var count = 0;
            foreach(var item in sequence)
            {
                fibonacciHeap.Count.Should().Be(count++);
                fibonacciHeap.Push(item);
            }
            foreach (var item in sequence) 
            {
                fibonacciHeap.Count.Should().Be(count--);
                fibonacciHeap.PopMin();
            }
        }

        [TestCase(new byte[]{ 2 })]
        [TestCase(new byte[]{ 5, 2 })]
        [TestCase(new byte[]{ 5, 2 })]
        public void ShouldClear(byte[] sequence)
        {
            var fibonacciHeap = new FibonacciHeap<byte>();
            
            foreach(var item in sequence)
            {
                fibonacciHeap.Push(item);
            }

            fibonacciHeap.Clear();

            fibonacciHeap.Count.Should().Be(0);

            Assert.Throws<System.NullReferenceException>( () =>  fibonacciHeap.PopMin() );
        }

        [TestCase(new byte[]{ 2 }, 2)]
        [TestCase(new byte[]{ 5, 2 }, 2)]
        [TestCase(new byte[]{ 5, 2, 1, 3, 7 }, 1)]
        public void ShouldPeek(byte[] sequence, byte min)
        {
            var fibonacciHeap = new FibonacciHeap<byte>();
            
            foreach(var item in sequence)
            {
                fibonacciHeap.Push(item);
            }

            fibonacciHeap.Peek().Should().Be(min);
        }
    }
}