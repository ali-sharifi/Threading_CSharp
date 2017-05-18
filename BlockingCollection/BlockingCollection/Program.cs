using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockingCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {

                foreach (string v in col.GetConsumingEnumerable())
                {
                    Console.WriteLine(v);
                }

                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });

            Task write = Task.Run(() =>
                {
                    while (true)
                    {
                        string s = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(s))
                        {
                            break;
                        }
                    }
                });
            write.Wait();
            //Task.WaitAll(new Task[] { read,write});
        }
    }
}
