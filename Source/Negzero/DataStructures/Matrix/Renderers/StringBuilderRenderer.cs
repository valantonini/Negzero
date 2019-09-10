using System.Text;

namespace Negzero.DataStructures.Matrix.Renderers
{
    public class StringBuilderRenderer : IRenderMatrix
    {
        private readonly int _height;
        private readonly int _width;
        private StringBuilder _stringBuilder;
        public StringBuilderRenderer(int height, int width, StringBuilder stringBuilder)
        {
            _height = height;
            _width = width;
            _stringBuilder = stringBuilder;
        }

        public void RenderTile((int x, int y) position, byte value)
        {
            _stringBuilder.Append(value); // square. https://en.wikipedia.org/wiki/Geometric_Shapes
            _stringBuilder.Append(" ");
            if (position.y == _width - 1)
            {
                _stringBuilder.AppendLine();
            }
        }
    }
}