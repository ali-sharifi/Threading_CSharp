using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.ThreadPool.QueueUserWorkItem((s) =>
                {
                    Console.WriteLine("Working on a thread from ThreadPool");
                });

            Console.ReadKey();
        }
    }
}
