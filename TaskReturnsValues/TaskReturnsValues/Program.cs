using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskReturnsValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = Task.Run(() =>
            {
                return 50;
            });
            //t.Wait(); no need for this
            Console.WriteLine(t.Result);
        }
    }
}
