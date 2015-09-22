using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = new Floyd();
            f.PrintPath();

            Console.Read();
        }
    }
}
