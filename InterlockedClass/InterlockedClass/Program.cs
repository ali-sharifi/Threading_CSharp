using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterlockedClass
{
    class Program
    {
        public static int value = 1;
        static void Main(string[] args)
        {
            int n = 0;
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Interlocked.Increment(ref n);
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                Interlocked.Decrement(ref n);
            }
            up.Wait();
            Console.WriteLine(n);

            if (Interlocked.Exchange(ref n, 0) == 0)
            {
                Console.WriteLine("InterlockedClass");
            }



            Task t1 = Task.Run(() =>
            {
                //if (value == 1)
                //{
                    Thread.Sleep(1000);
                    //value = 2;
                    Interlocked.CompareExchange(ref value, 2, 1);

                //}
            });

            Task t2 = Task.Run(() =>
            {
                value = 3;
            });
            Task.WaitAll(t1, t2);
            Console.WriteLine(value);
        }
    }
}
