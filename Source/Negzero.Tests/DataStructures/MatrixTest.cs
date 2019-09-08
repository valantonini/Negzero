using NUnit.Framework;
using FluentAssertions;

namespace Negzero.DataStructures.Tests
{
    public class MatrixTest
    {
        [Test]
        public void ShouldInstantiateAMatrix()
        {
            var matrix = new Matrix(4, 5);

            matrix.Height.Should().Be(4);
            matrix.Width.Should().Be(5);
        }
    }
}