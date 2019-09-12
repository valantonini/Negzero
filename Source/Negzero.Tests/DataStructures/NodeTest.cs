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


            greatGrandchild.Parent.Should().BeNull();

            grandchild1.Parent.Should().Be(child);
            grandchild2.Parent.Should().Be(child);
            
            child.Parent.Should().Be(parent);
        }
    }
}