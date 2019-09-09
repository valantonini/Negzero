using NUnit.Framework;
using FluentAssertions;

namespace Negzero.DataStructures.Matrix.Tests
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

        [Test]
        public void ShouldSet2dCoordinates()
        {
            var matrix = new Matrix(3, 3);

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