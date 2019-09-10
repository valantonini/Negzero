using NUnit.Framework;
using FluentAssertions;
using Negzero.DataStructures.PriorityQueue;

namespace Negzero.Tests.DataStructures
{
    public class SimplePriorityQueueTest
    {
        [Test]
        public void ShouldInstantiateASimplePriorityQueue()
        {
            var priorityQueue = new SimplePriorityQueue<byte>();
            priorityQueue.Should().NotBeNull();
        }
    }
}