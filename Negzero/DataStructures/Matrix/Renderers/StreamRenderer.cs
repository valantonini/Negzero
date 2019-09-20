using System.Text;
using System.IO;

namespace Negzero.DataStructures.Matrix.Renderers
{
    /*
        using (var memoryStream = new System.IO.MemoryStream())
        using(var streamwriter = new System.IO.StreamWriter(memoryStream))
        {
            matrix.Render(new StreamRenderer(4,5, streamwriter));
            
            memoryStream.Position = 0;
            var reader = new System.IO.StreamReader(memoryStream);
            System.Console.WriteLine(reader.ReadToEnd());
        }
     */
    public class StreamRenderer : IRenderMatrix
    {
        private readonly int _height;
        private readonly int _width;
        private StreamWriter _stream;
        public StreamRenderer(int height, int width, StreamWriter stream)
        {
            _height = height;
            _width = width;
            _stream = stream;
        }

        public void RenderTile((int x, int y) position, byte value)
        {
            _stream.Write(value); // square. https://en.wikipedia.org/wiki/Geometric_Shapes
            _stream.Write(" ");
            if (position.y == _width - 1)
            {
                _stream.WriteLine();
            }
            if(position.x == _height - 1 && position.y == _width - 1){
                _stream.Flush();
            }
        }
    }
}