using System;

namespace Negzero.DataStructures.Matrix.Renderers
{
    public class ConsoleRenderer : IRenderMatrix
    {
        private readonly int _height;
        private readonly int _width;
        public ConsoleRenderer(int height, int width)
        {
            _height = height;
            _width = width;
        }

        public void RenderTile((int x, int y) position, byte value)
        {
            Console.ForegroundColor = value == 0 ? ConsoleColor.White : ConsoleColor.Red;
            Console.Write('\u25a1'); // square. https://en.wikipedia.org/wiki/Geometric_Shapes
            Console.Write(" ");
            if (position.y == _width - 1)
            {
                Console.WriteLine();
            }
        }
    }
}