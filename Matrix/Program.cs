using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix ma = new Matrix(3, 3);

            ma.SetValue(2);
            ma[2, 2] = 10;

            Matrix mab = new Matrix(ma);

            Matrix n = ma * mab;
            n.ToString();


            Console.Read();
        }
    }
}
