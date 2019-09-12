using NUnit.Framework;
using FluentAssertions;
using Negzero.DataStructures.PriorityQueue;
using System;
using System.Linq;
using System.Collections.Generic;
using NSubstitute;

namespace Negzero.Tests.DataStructures
{
    public class NodeTest
    {
       [Test]
        public void ShouldSetParent()
        {
            var parent = Substitute.ForPartsOf<Node<int>>(5);
            var child = Substitute.ForPartsOf<Node<int>>(3);

            parent.AddChild(child);

            parent.Parent.Should().Be(null);
            child.Parent.Should().Be(parent);
        }

        [Test]
        public void ShouldTrackHeight_Parent()
        {
            var parent = Substitute.ForPartsOf<Node<int>>(5);
            var child = Substitute.ForPartsOf<Node<int>>(3);

            parent.AddChild(child);

            parent.Height.Should().Be(1);
            child.Height.Should().Be(0);
        }


        [Test]
        public void ShouldTrackHeight_Grandparent()
        {
            var parent = Substitute.ForPartsOf<Node<int>>(5);
            var child = Substitute.ForPartsOf<Node<int>>(3);
            var grandchild = Substitute.ForPartsOf<Node<int>>(1);

            parent.AddChild(child);
            child.AddChild(grandchild);

            parent.Height.Should().Be(2);
            child.Height.Should().Be(1);
            grandchild.Height.Should().Be(0);
        }

        [Test]
        public void ShouldTrackHeight_GreatGrandChild()
        {
            var parent = Substitute.ForPartsOf<Node<int>>(9);
            
            var child = Substitute.ForPartsOf<Node<int>>(7);
            
            var grandchild1 = Substitute.ForPartsOf<Node<int>>(6);
            var grandchild2 = Substitute.ForPartsOf<Node<int>>(3);
            
            var greatGrandchild = Substitute.ForPartsOf<Node<int>>(1);

            parent.AddChild(child);
            
            child.AddChild(grandchild1);
            child.AddChild(grandchild2);

            grandchild2.AddChild(greatGrandchild);

            parent.Height.Should().Be(3);
            child.Height.Should().Be(2);
            grandchild1.Height.Should().Be(0);
            grandchild2.Height.Should().Be(1);
            greatGrandchild.Height.Should().Be(0);
        }

        [Test]
        public void ShouldTrackHeight_RecalOnRemoval()
        {
            var parent = Substitute.ForPartsOf<Node<int>>(9);
            
            var child = Substitute.ForPartsOf<Node<int>>(7);
            
            var grandchild1 = Substitute.ForPartsOf<Node<int>>(6);
            var grandchild2 = Substitute.ForPartsOf<Node<int>>(3);
            
            var greatGrandchild = Substitute.ForPartsOf<Node<int>>(1);

            parent.AddChild(child);
            
            child.AddChild(grandchild1);
            child.AddChild(grandchild2);

            grandchild2.AddChild(greatGrandchild);

            grandchild2.RemoveChild(greatGrandchild);

            parent.Height.Should().Be(2);
            child.Height.Should().Be(1);
            grandchild1.Height.Should().Be(0);
            grandchild2.Height.Should().Be(0);
        }
        [Test]
        public void ShouldTrackRelationship_OnRemoval()
        {
            var n1 = Substitute.ForPartsOf<Node<int>>(9);
            
            var n1_1 = Substitute.ForPartsOf<Node<int>>(7);
            
            var n1_1_1 = Substitute.ForPartsOf<Node<int>>(6);
            var n1_1_2 = Substitute.ForPartsOf<Node<int>>(3);
            
            var n1_1_2_1 = Substitute.ForPartsOf<Node<int>>(1);

            n1.AddChild(n1_1);
            
            n1_1.AddChild(n1_1_1);
            n1_1.AddChild(n1_1_2);

            n1_1_2.AddChild(n1_1_2_1);

            n1_1_2.RemoveChild(n1_1_2_1);

            n1_1_2_1.Parent.Should().BeNull();
            n1_1_1.Parent.Should().Be(n1_1);
            n1_1_2.Parent.Should().Be(n1_1);
            n1_1.Parent.Should().Be(n1);
        }

        [Test]
        public void ShouldTrackHeight_RecalOnMerge()
        {
            var n1 = Substitute.ForPartsOf<Node<int>>(9);
            
            var n1_1 = Substitute.ForPartsOf<Node<int>>(7);
            
            var n1_1_1 = Substitute.ForPartsOf<Node<int>>(6);
            var n1_1_2 = Substitute.ForPartsOf<Node<int>>(3);
            
            var n2 = Substitute.ForPartsOf<Node<int>>(1);
            var n2_1 = Substitute.ForPartsOf<Node<int>>(1);

            n1.AddChild(n1_1);
            
            n1_1.AddChild(n1_1_1);
            n1_1.AddChild(n1_1_2);

            n2.AddChild(n2_1);

            n1_1_2.AddChild(n2);

            n1.Height.Should().Be(4);
        }
    }
}