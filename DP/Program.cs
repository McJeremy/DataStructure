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

            DPCoin coin = new DPCoin();
            coin.Count(12);

            LIS lis = new LIS();
            lis.Count(new int[]{
                5, 3, 4, 8, 6, 7,9,11,13,4,5,7
            });
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

    /// <summary>
    /// 动态规划的求解最小硬币数问题
    /// </summary>
    public class DPCoin
    {
        //题目描述：如果我们有面值为1元、3元和5元的硬币若干枚，如何用最少的硬币凑够11元？
        int[] coins = { 1, 3, 5 };  //标识面值有1、3、5
        int[] nums; //标识每种硬币数需要的最少硬币

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public void Count(int totalNum)
        {
            nums = new int[totalNum];

            nums[0] = 0;    //标识0元的，需要0个硬币

            //状态转移方程：d(i)=min{ d(i-vj)+1 }
            for (var i = 1; i < totalNum; i++)
            {
                nums[i] = 9999;
                for (var j = 0; j < 3 &&coins[j]<=i ; j++)
                {
                    //这里的i-coins[j]的意思，表示需要组成总共面额i元，从中取出coins[j]元
                    //而剩下的则是已经在之前就算出来的最小（也就是大问题分解为小问题）
                    if (nums[i - coins[j]] + 1 < nums[i])
                    {
                        nums[i] = nums[i - coins[j]]+1;
                    }
                }
            }

            for (var i = 1; i < nums.Length; i++)
            {
                Console.WriteLine("筹够 {0}元，需要{1}枚硬币", i, nums[i]);
            }
        }
    }

    /// <summary>
    /// 最长递增子序列
    /// </summary>
    public class LIS
    {
        /*
        1、寻找最优子结构
我们设待求的序列为Xn,同样的如果我们已经求得了前n-1个序列的最长递增子序列，那么Xn的最长递增子序列要么等于前n-1个的最长递增子序，要么等于其加1。这里的问题有些复杂，复杂的原因就在于，前n-1个序列的最长递增子序，可能不止一个，设其长度为Ln-1。面对这种情况，我们只需用Xn的最后的元素与递增序列长度为Ln-1的最长序列的最小值进行比较。
2、递归定义最优解结构
   因为序列的每一项，都可以构成长度为1的递增自序列，所以最小值为1.
3、自底向上求解最优解（与算法导论上的方法一样，只是没加记录项）

            4、状态方程 lis(i)=max(1,lis(j)+1),其中j<1,A[j]<=A[i]
        */
        public void Count(int[] arr)
        {
            int iMaxL = 0;
            int[] iEachL = new int[arr.Length];
            iEachL[0] = 1;  //第一个元素的最长递增子序列长度一定是1

            for (var i = 1; i < arr.Length; i++)
            {
                iEachL[i] = 1;
                if (arr[i - 1] < arr[i])
                {
                    iEachL[i] = iEachL[i - 1] + 1;
                }

                if (iEachL[i] > iMaxL)
                {
                    iMaxL = iEachL[i];
                }
            }

            for (var j = 0; j < iEachL.Length; j++)
            {
                Console.WriteLine("截止元素{0},构成的最长增长子序列长度是:{1}", arr[j], iEachL[j]);
            }

            Console.WriteLine("最长子序列长度是:{0}", iMaxL);
        }
    }

}
