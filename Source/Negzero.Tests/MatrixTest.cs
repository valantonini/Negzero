using NUnit.Framework;
using Negzero;

namespace Negzero.Tests {
    public class MatrixTest
    {
        [Test]
        public void ShouldInstantiate()
        {
            var matrix = new Negzero.Matrix();
            Assert.IsNotNull(matrix);
        }
    }
}