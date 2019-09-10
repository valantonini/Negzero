using NUnit.Framework;
using FluentAssertions;
using Negzero.DataStructures.Matrix;

namespace Negzero.Tests.DataStructures
{
    public class ByteMatrixTest
    {
        [Test]
        public void ShouldInstantiateAMatrix()
        {
            var matrix = new ByteMatrix(4, 5);

            matrix.Height.Should().Be(4);
            matrix.Width.Should().Be(5);
        }

        [Test]
        public void ShouldSet2dCoordinates()
        {
            var matrix = new ByteMatrix(3, 3);

            byte index = 0;
            for (var x = 0; x < 3; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    matrix[(x, y)] = index++;
                }
            }

            byte expected = 0;
            foreach (var position in matrix.ToArray())
            {
                position.Should().Be(expected++);
            }
        }
    }
}