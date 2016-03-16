using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonQuestions1
{
    public class SnakeArray
    {
        /// <summary>
        /// N阶树形数组
        /// </summary>
        /// <param name="N"></param>
        public static void Run(int N)
        {
            Console.WriteLine("蛇形数组：\r\n");

            int iMax = N * N;

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    Console.Write((j + 1) * (i + 1));
                    Console.Write("  ");
                }
                Console.WriteLine("\r\n");
            }
        }
    }
}
