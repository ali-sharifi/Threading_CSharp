using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentStack
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            stack.Push(42);

            int result;
            if (stack.TryPop(out result))
            {
                Console.WriteLine($"Popped: {result}");
            }
            stack.PushRange(new int[] { 1, 2, 3 });
            int[] values = new int[3];
            stack.TryPopRange(values);

            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
        }
    }
}
