using System;
using Negzero;
using Negzero.DataStructures.Matrix;
using Negzero.DataStructures.Matrix.Renderers;
using Negzero.BitmapRenderer;

namespace Negzero.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new Matrix(4,5);
            matrix[(2,2)] = 1;

            matrix.Render(new Renderer(4,5, "/Users/val/tmp/dungeon2.png"));
        }
    }
}
