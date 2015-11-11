using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorts
{
    class Program
    {
        static readonly int[] x = { 1, 2, 3, 5, 2, 3 };
        static void Main(string[] args)
        {
            //QuickSort.Sort(x, 0, x.Length - 1);

            //SelectionSort.Sort(x);

            InsertSort.Sort(x);

            for (var i = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i]);
            }
        }
    }
}
