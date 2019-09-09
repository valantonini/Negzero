using System;
using System.Collections.ObjectModel;
using Negzero.DataStructures.Matrix.Renderers;

namespace Negzero.DataStructures.Matrix
{
    public class Matrix
    {
        private readonly byte[] _matrix;
        public int Height { get; private set; }
        public int Width { get; private set; }

        public Matrix(int height, int width)
        {
            Height = height;
            Width = width;
            _matrix = new byte[Height * Width];
        }

        public byte this[(int x, int y) point]
        {
            get => _matrix[point.x * Width + point.y];
            set => _matrix[point.x * Width + point.y] = value;
        }

        public ReadOnlyCollection<byte> ToArray()
        {
            return Array.AsReadOnly(_matrix);
        }

        public void Render(IRenderMatrix renderer)
        {
            for (var x = 0; x < Height; x++)
            {
                for (var y = 0; y < Width; y++)
                {
                    renderer.RenderTile((x, y), this[(x, y)]);
                }
            }
        }
    }
}