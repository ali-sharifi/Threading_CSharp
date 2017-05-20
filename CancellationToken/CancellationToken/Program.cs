using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationToken
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancelaltionTokenSource = new CancellationTokenSource();
            var token = cancelaltionTokenSource.Token;

            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.WriteLine("*");
                    Thread.Sleep(1000);
                }
                token.ThrowIfCancellationRequested();
            }, token);

            try
            {
                Console.WriteLine("Press enter to stop the task");
                Console.ReadLine();
                cancelaltionTokenSource.Cancel();
                task.Wait();
            }
            //catch (OperationCanceledException ex)
            //{
            //    Console.WriteLine($"OperationCancellationException {ex.Message}");
            //}
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            Console.WriteLine("Press enter to end the application");
            Console.ReadLine();
        }
    }
}
