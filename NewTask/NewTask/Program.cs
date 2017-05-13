using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = Task.Run(() => {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("*");
                }
            });

            //Task t = new Task(() => {
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine("*");
            //    }
            //});
            //t.Start();
            t.Wait();
        }
    }
}

