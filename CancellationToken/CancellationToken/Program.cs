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

            //string s = "test";
            int s = 1;
            switch (s)
            {
                case 1:
                    s = 4;
                    goto case 4;
                case 4:
                    s = 5;
                    break;
                default:
                    break;
            }

            int[] values = { 1, 2, 3, 4, 5, 6 };
            for (int x = 0, y = 1;
            ((x < values.Length) && (y >= 0));
            x++, y--)
            {
                Console.Write(values[x]);
                Console.Write(values[y]);
            }

        

            //for (;;)
            //{
            //    Console.WriteLine("H");
            //}
        }
    }
}
