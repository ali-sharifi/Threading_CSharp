using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();
            t.Priority = ThreadPriority.Highest;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main Thread : Do some work.");
                Thread.Sleep(0);
            }
            t.Join();
        }

        private static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                Thread.Sleep(0);
            }
        }
    }
}
