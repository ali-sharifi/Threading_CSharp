using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 100000000);
            var parallelResult = numbers.AsParallel()
                                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                                .WithDegreeOfParallelism(4) //represent number of processors
                                .Where(i => i % 2 == 0)
                                .ToArray();

            //parallel processing does not guarantee any order
            var numbers1 = Enumerable.Range(0, 10);
            var parallelResult1 = numbers1.AsParallel()
                                .AsOrdered()
                                .Where(i => i % 2 == 0);
            //.ToArray();

            foreach (var item in parallelResult1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            parallelResult1.ForAll(c => Console.WriteLine(c));

            try
            {
                var parallelResult2 = numbers.AsParallel()
                    .Where(i => IsEven(i));
                parallelResult2.ForAll(p => Console.WriteLine(p));
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"There were {ex.InnerExceptions.Count} exceptions");
            }
        }

        private static bool IsEven(int i)
        {
            if (i % 10 == 0)
            {
                throw new ArgumentException("i");
            }
            return i % 2 == 0;
        }
    }
}
