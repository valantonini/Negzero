using System;
using Negzero;
using Negzero.DataStructures.Matrix;
using Negzero.DataStructures.Matrix.Renderers;
using Negzero.BitmapRenderer;
using Negzero.DataStructures.PriorityQueue;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Negzero.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            System.Console.WriteLine();

            var mod = 10000;
            var random = new Random(123);

            var numbers = Enumerable
                            .Range(0, 200000)
                            .Select( _ => random.Next(1, 1000000))
                            .Distinct()
                            .ToList();

            var timer = Stopwatch.StartNew();
            var heap = new FibonacciHeap<int>();
            for (var i = 0; i < numbers.Count; i++)
            {
                heap.Push(numbers[i]);  
                if (i % mod == 0) {
                    heap.PopMin();
                }  
            }
            timer.Stop();
            var heapElapsed = timer.ElapsedMilliseconds;
            System.Console.WriteLine($"Heap: {numbers.Count} processed in {heapElapsed}ms");

            // timer = Stopwatch.StartNew();
            // var list = new List<int>();
            // for (var i = 0; i < numbers.Count; i++)
            // {
            //     list.Add(numbers[i]);  
            //     if (i % mod == 0) {
            //         list.Remove(list.Min());
            //     }  
            // }
            // timer.Stop();
            // System.Console.WriteLine($"List: {numbers.Count} processed in {timer.ElapsedMilliseconds}ms");

            timer = Stopwatch.StartNew();
            var queueB = new PriorityQueueB<int>();
            for (var i = 0; i < numbers.Count; i++)
            {
                queueB.Push(numbers[i]);  
                if (i % mod == 0) {
                    queueB.PopMin();
                }  
            }
            timer.Stop();
            var queueElapsed = timer.ElapsedMilliseconds;
            System.Console.WriteLine($"Queue: {numbers.Count} processed in {queueElapsed}ms");

            System.Console.WriteLine();
            System.Console.WriteLine($"variance {heapElapsed - queueElapsed}ms ({heapElapsed / queueElapsed * 100}%)");
            System.Console.WriteLine();
        }
    }
}
