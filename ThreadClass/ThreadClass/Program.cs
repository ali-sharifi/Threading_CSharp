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
            Thread t1 = new Thread(new ThreadStart(ThreadMethod));
            Thread t2 = new Thread(new ParameterizedThreadStart(ThreadMethod));

            //t.Priority = ThreadPriority.Highest;
            //t.IsBackground = true;
            t1.Start();
            t2.Start(5);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main Thread : Do some work.");
                if (i==1)
                {
                    t1.Abort();
                    t2.Abort();
                }
                Thread.Sleep(0);

            }
            t1.Join();
            t2.Join();
        }

        private static void ThreadMethod()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"ThreadProc1: {i}");
                Thread.Sleep(1000);
            }
        }
        private static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine($"ThreadProc2: {i}");                
                Thread.Sleep(1000);
            }
        }
    }
}
