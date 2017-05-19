using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentBag
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(4);
            bag.Add(31);
            int result;
            if (bag.TryTake(out result))
            {
                Console.WriteLine(result);
            }
            if (bag.TryPeek(out result))
            {
                Console.WriteLine($"There is a next item: {result}");
            }

            ConcurrentBag<int> bag1 = new ConcurrentBag<int>();
            Task.Run(()=>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });
            Task.Run(()=>
            {
                foreach (var i in bag)
                {
                    Console.WriteLine(i);
                }
            }).Wait();
        }
    }
}
