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
    }
}