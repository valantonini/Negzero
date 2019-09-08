using System;
using System.Collections.ObjectModel;

namespace Negzero.DataStructures
{
    public class Matrix
    {
        private byte[] _matrix;
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

        public ReadOnlyCollection<byte> ToArray() {
            return Array.AsReadOnly(_matrix);
        }
    }
}