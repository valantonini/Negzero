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

            using (var memoryStream = new System.IO.MemoryStream())
            using(var streamwriter = new System.IO.StreamWriter(memoryStream))
            {
                matrix.Render(new StreamRenderer(4,5, streamwriter));
                
                memoryStream.Position = 0;
                var reader = new System.IO.StreamReader(memoryStream);
                System.Console.WriteLine(reader.ReadToEnd());
            }

        }
    }
}
