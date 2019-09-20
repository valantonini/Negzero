using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Negzero.DataStructures.Matrix.Renderers;

namespace Negzero.BitmapRenderer
{
    public class Renderer : IRenderMatrix
    {
        private readonly int _height;
        private readonly int _width;
        private readonly Bitmap _bitmap;
        private readonly Graphics _graphics;
        private readonly string _filename;
        private const int TILE_SIZE = 16;
        
        public Renderer(int height, int width, string filename)
        {
            _height = height;
            _width = width;
            _bitmap = new Bitmap(width * TILE_SIZE, height * TILE_SIZE + 1);
            _graphics = Graphics.FromImage(_bitmap);
            _filename = filename;
        }

        public void RenderTile((int x, int y) position, byte value)
        {
            var brush = value == 0 ? Brushes.Black : Brushes.Red;
            var x = position.x * TILE_SIZE;
            var y = position.y * TILE_SIZE;
            _graphics.FillRectangle(brush, x, y, TILE_SIZE, TILE_SIZE);
            _graphics.DrawRectangle(new Pen(Brushes.White), new Rectangle(){ Height = TILE_SIZE, Width = TILE_SIZE, X = x, Y = y});

            if(position.x == _height - 1 && position.y == _width - 1){
                _graphics.Dispose();
                _bitmap.Save(_filename, ImageFormat.Png);
                _bitmap.Dispose();
            }
        }
    }
}