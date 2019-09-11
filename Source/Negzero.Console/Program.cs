using System;
using Negzero;
using Negzero.DataStructures.Matrix;
using Negzero.DataStructures.Matrix.Renderers;
using Negzero.BitmapRenderer;
using Negzero.DataStructures.PriorityQueue;

namespace Negzero.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // var matrix = new ByteMatrix(4,5);
            // matrix[(2,2)] = 1;

            // matrix.Render(new Renderer(4,5, "/Users/val/tmp/dungeon2.png"));
            var heap = new FibonacciHeap<byte>();
            foreach(var item in new byte[]{ 5, 2}) 
            {
                heap.Push(item);    
            }
            for (var i = 0; i < heap.Count; i++) 
            {
                heap.PopMin();
            }
        }
    }
}
