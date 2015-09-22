using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeArray
{
    class Program
    {
        //目前有问题

        static int[] x = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        static  int[] c = new int[11];
        static void Main(string[] args)
        {
            Console.WriteLine(3 & -3);
            //先生成求和树
            for (int i = 1; i <= x.Length-1; i++)
            {
                add(i, x[i]);
            }

            Console.WriteLine(Sum(10));
            
            Console.Read();
        }
        static void add(int k, int num)
        {
            //改变一个数，向上更新它的父级节点的值。
            //而它的父级节点是哪一个呢？就通过 Lowbit(k)来计算
            //比如，改变的是3，那么它的父级节点是：3&-3=1,而4的父级节点是1&-1,递归直到最顶上
            while (k < 11)
            {                
                c[k] += num;
                k += Lowbit(k);
            }
        }


        static int Sum(int pos)
        {
            int sum = 0;
            while (pos > 0)
            {
                sum += c[pos];
                pos -= Lowbit(pos);
            }
            return sum;
        }

        static int Lowbit(int t)
        {
            return t & -t;
        }

    }
}
