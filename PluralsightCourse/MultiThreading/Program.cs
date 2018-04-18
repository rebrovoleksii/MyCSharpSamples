using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {
        private static BlockingCollection<int> _intsToProcess = new BlockingCollection<int>();
        private static int _sum = 0;

        static void Main(string[] args)
        {
            //for (int i = 0; i < 1000; i++)
            //{
            //    _intsToProcess.Enqueue(i*2);
            //}
            DequeueInts();
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("Please enter a number:");
            //    var input = Console.ReadLine();
            //    int result;
            //    if (int.TryParse(input, out result))
            //    {
            //        _intsToProcess.Add(result);
            //    }
            //}
            Parallel.ForEach(new int[3] { 1, 5, 11 }, new ParallelOptions { MaxDegreeOfParallelism = 3 }, (i) =>
                   {
                       for (int j = 1; j < 100; j++)
                       {
                           Thread.Sleep((15-i) * 100);
                           _intsToProcess.Add(i * j);
                       }
                   }
            );

            //Console.WriteLine("Current queue count: " + _intsToProcess.Count);
            //Console.WriteLine("Sum so far: " + _sum);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        private static void DequeueInts()
        {
            Task.Factory.StartNew(() =>
            {
                while (!_intsToProcess.IsCompleted)
                {
                    int number = _intsToProcess.Take();
                    Console.WriteLine($"Number {number} was dequeued.");
                }
            });
        }
    }
}
