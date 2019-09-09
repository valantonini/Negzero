using System;
using Negzero;
using Negzero.DataStructures.Matrix;
using Negzero.DataStructures.Matrix.Renderers;

namespace Negzero.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new Matrix(4,5);
            matrix[(2,2)] = 1;
            matrix.Render(new ConsoleRenderer(4,5));
        }
    }
}
