using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWithContinuation
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = Task.Run(() =>
            {
                return 50;
            });
            Console.WriteLine(t.Result);

            t.ContinueWith((i) =>
                            {
                                Console.WriteLine("Canceled");
                            }, TaskContinuationOptions.OnlyOnCanceled);
            t.ContinueWith((i) =>
                            {
                                Console.WriteLine("Faulted");
                            }, TaskContinuationOptions.NotOnFaulted);

            var completedTask = t.ContinueWith((i) =>
                              {
                                  Console.WriteLine("Completed");
                              }, TaskContinuationOptions.OnlyOnRanToCompletion);
            completedTask.Wait();
        }
    }
}
