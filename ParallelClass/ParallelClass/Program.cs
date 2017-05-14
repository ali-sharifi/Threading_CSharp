using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(0, 10, i => { Console.WriteLine(i); });

            var numbers = Enumerable.Range(100, 10);
            var result = Parallel.ForEach(numbers, (int i, ParallelLoopState loopstate) =>
                              {
                                  Thread.Sleep(1000);
                                  Console.WriteLine(i);
                                  if (i == 104)
                                  {
                                      //loopstate.Break();
                                      loopstate.Stop();
                                  }
                              });
            Console.WriteLine($"iscomplete: {result.IsCompleted}, LowestBreakIteration: {result.LowestBreakIteration}");
        }
    }
}
