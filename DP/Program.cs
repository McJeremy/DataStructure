using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IterFib(6));

            Console.Read();
        }

        #region 动态规划实现的斐波那契
        //使用递归实现的，时间复杂度是O(N^2)
        static int IterFib(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            else
            {
                return IterFib(n - 1) + IterFib(n - 2);
            }
        }

        /// <summary>
        /// 使用动态规划实现的，时间复杂度是O(N)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int IterFibWithDB(int n)
        {
            int[] val = new int[n];
            if (n <= 2)
            {
                return 1;
            }
            else
            {
                val[1] = 1;
                val[2] = 2;

                for (int i = 3; i < n; i++)
                {
                    val[i] = val[i - 1] + val[i - 2];
                }
            }
            return val[n - 1];
        }
        #endregion
    }


}
